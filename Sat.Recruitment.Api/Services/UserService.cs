using Sat.Recruitment.Api.Bussiness;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Repositories;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserBussiness _userBussiness;
        private readonly IUserRepository _userRepository;

        public const string DUPLICATE_MESSAGE = "The user is duplicated";
        public const string USER_CREATED_MESSAGE = "User Created";

        public UserService(IUserBussiness userBussiness, IUserRepository userRepository)
        {
            _userBussiness = userBussiness;
            _userRepository = userRepository;
        }

        public async Task<Result> CreateAsync(User newUser)
        {
            _userBussiness.CalculateUserMoneyGift(ref newUser);

            newUser.Email = _userBussiness.NormalizeEmail(newUser.Email);

            var users = _userRepository.ReadUsersFromFile();

            foreach(var user in users)
            {
                if(_userBussiness.IsDuplicated(user, newUser))
                {
                    Debug.WriteLine(DUPLICATE_MESSAGE);
                    return new Result(false, DUPLICATE_MESSAGE);
                }
            }

            _userRepository.SaveUser(newUser);
            Debug.WriteLine(USER_CREATED_MESSAGE);

            return new Result(true, string.Empty);
        }
    }
}
