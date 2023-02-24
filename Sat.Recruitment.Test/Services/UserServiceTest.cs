using Moq;
using Sat.Recruitment.Api.Bussiness;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Repositories;
using Sat.Recruitment.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sat.Recruitment.Api.Tests.Services
{
    public class UserServiceTests
    {
        private readonly IUserBussiness _userBusiness;
        private readonly IUserRepository _userRepository;

        public UserServiceTests()
        {
            _userBusiness = new UserBussiness();
            _userRepository = new UserRepository();
        }

        [Fact]
        public async Task CreateAsync_DuplicateUser_ReturnsResultWithFalseIsSuccess()
        {
            // Arrange
            var user = new User
            {
                Name = "Romina",
                Email = "romina_velez@gmail.com",
                Phone = "+531234567890",
                Address = "Alem",
                UserType = "Normal",
                Money = 100
            };

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.ReadUsersFromFile()).Returns(new List<User> { user });

            var userBusinessMock = new Mock<IUserBussiness>();
            userBusinessMock.Setup(x => x.CalculateUserMoneyGift(ref user));
            userBusinessMock.Setup(x => x.NormalizeEmail(user.Email)).Returns(user.Email);
            userBusinessMock.Setup(x => x.IsDuplicated(user, user)).Returns(true);

            var userService = new UserService(userBusinessMock.Object, userRepositoryMock.Object);

            // Act
            var result = await userService.CreateAsync(user);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(UserService.DUPLICATE_MESSAGE, result.Errors);
        }
    }
}
