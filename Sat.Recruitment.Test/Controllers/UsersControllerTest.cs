using Microsoft.AspNetCore.Mvc;
using Moq;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Sat.Recruitment.Api.Tests.Controllers
{
    public class UsersControllerTests
    {
        private readonly UsersController _controller;
        private readonly Mock<IUserService> _mockUserService;

        public UsersControllerTests()
        {
            _mockUserService = new Mock<IUserService>();
            _controller = new UsersController(_mockUserService.Object);
        }

            [Fact]
            public async Task CreateUserController_ReturnsCorrectResult()
            {
                // Arrange
                var mockService = new Mock<IUserService>();
                var controller = new UsersController(mockService.Object);
                // Arrange
                var userInfo = new User
                {
                    Name = "Franco",
                    Email = "Franco.Perez@gmail.com",
                    Address = "Alvear y Colombres",
                    Phone = "+534645213542",
                    UserType = "Premium",
                    Money = 112234
                };
                var expectedResult = new Result(true, "");

                mockService.Setup(service => service.CreateAsync(userInfo)).ReturnsAsync(expectedResult);

                // Act
                var actionResult = await controller.CreateUser(userInfo);
                var result = actionResult as Result;

                // Assert
                Assert.NotNull(result);
                Assert.True(result.IsSuccess);
                Assert.Equal("", result.Errors);
            }
    }
}
