using System;
using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Services;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    public partial class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("/create-user")]
        public async Task<Result> CreateUser(User userInfo)
        {
            try
            {
                return await _userService.CreateAsync(userInfo);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return new Result(false, ex.Message);

            }
        }
    }
}
