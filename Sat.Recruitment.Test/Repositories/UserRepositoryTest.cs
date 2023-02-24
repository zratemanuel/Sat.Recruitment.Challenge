using Xunit;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Repositories;
using System.Linq;

namespace Sat.Recruitment.Api.Tests.Repositories
{
    public class UserRepositoryTests
    {
        [Fact]
        public void ReadUsersFromFile_ReturnsListOfUsers()
        {
            // Arrange
            var repository = new UserRepository();

            // Act
            var result = repository.ReadUsersFromFile();

            // Assert
            Assert.IsType<System.Collections.Generic.List<User>>(result);
            Assert.True(result.Count > 0);
        }
    }
}
