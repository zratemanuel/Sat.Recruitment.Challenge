using Sat.Recruitment.Api.Models;
using System.Collections.Generic;

namespace Sat.Recruitment.Api.Repositories
{
    public interface IUserRepository
    {
        public List<User> ReadUsersFromFile();

        public void SaveUser(User user);
    }
}
