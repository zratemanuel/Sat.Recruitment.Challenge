using Xunit;
using Sat.Recruitment.Api.Bussiness;
using Sat.Recruitment.Api.Models;

namespace Sat.Recruitment.Api.Tests
{
    public class UserBussinessTests
    {
        private readonly UserBussiness _userBusiness;

        public UserBussinessTests()
        {
            _userBusiness = new UserBussiness();
        }

        [Fact]
        public void CalculateUserMoneyGift_NormalUser_MoneyGreaterThan100_ShouldAddGift()
        {
            // Arrange
            var user = new User { UserType = UserBussiness.USER_TYPE_NORMAL, Money = 200 };
            var userBusiness = new UserBussiness();

            // Act
            userBusiness.CalculateUserMoneyGift(ref user);

            // Assert
            Assert.Equal(224, user.Money);
        }

        [Fact]
        public void CalculateUserMoneyGift_NormalUser_MoneyLessThan100AndGreaterThan10_ShouldAddGift()
        {
            // Arrange
            var user = new User { UserType = UserBussiness.USER_TYPE_NORMAL, Money = 50 };
            var userBusiness = new UserBussiness();

            // Act
            userBusiness.CalculateUserMoneyGift(ref user);

            // Assert
            Assert.Equal(90, user.Money);
        }

        [Fact]
        public void CalculateUserMoneyGift_NormalUser_MoneyLessThan10_ShouldNotAddGift()
        {
            // Arrange
            var user = new User { UserType = UserBussiness.USER_TYPE_NORMAL, Money = 5 };
            var userBusiness = new UserBussiness();

            // Act
            userBusiness.CalculateUserMoneyGift(ref user);

            // Assert
            Assert.Equal(5, user.Money);
        }

        [Fact]
        public void CalculateUserMoneyGift_PremiumUser_MoneyLessThan100_ShouldNotAddGift()
        {
            // Arrange
            var user = new User { UserType = UserBussiness.USER_TYPE_PREMIUM, Money = 50 };
            var userBusiness = new UserBussiness();

            // Act
            userBusiness.CalculateUserMoneyGift(ref user);

            // Assert
            Assert.Equal(50, user.Money);
        }

        [Fact]
        public void IsDuplicated_ReturnsTrue_WhenEmailIsDuplicate()
        {
            // Arrange
            var existingUser = new User
            {
                Email = "romina@example.com",
                Phone = "+5411252636",
                Name = "Romina Diaz",
                Address = "Alem 812"
            };

            var newUser = new User
            {
                Email = "ROMINA@example.com",
                Phone = "+5411252636",
                Name = "Romina Diaz",
                Address = "Alem 812"
            };

            // Act
            var result = _userBusiness.IsDuplicated(existingUser, newUser);

            // Assert
            Assert.True(result);
        }
    }
}