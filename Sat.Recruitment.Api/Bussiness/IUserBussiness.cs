using Sat.Recruitment.Api.Models;

namespace Sat.Recruitment.Api.Bussiness
{
    public interface IUserBussiness
    {
        public void CalculateUserMoneyGift(ref User user);
        public string NormalizeEmail(string email);
        public bool IsDuplicated(User existingUser, User newUser);
    }
}
