using System;
using Sat.Recruitment.Api.Models;

namespace Sat.Recruitment.Api.Bussiness
{
    public class UserBussiness : IUserBussiness
    {
        public const string USER_TYPE_NORMAL = "Normal";
        public const string USER_TYPE_SUPER_USER = "SuperUser";
        public const string USER_TYPE_PREMIUM = "Premium";

        public void CalculateUserMoneyGift(ref User user)
        {
            if (user.UserType == USER_TYPE_NORMAL)
            {
                if (user.Money > 100)
                {
                    var percentage = Convert.ToDecimal(0.12);
                    //If new user is normal and has more than USD100
                    var gif = user.Money * percentage;
                    user.Money = user.Money + gif;
                }
                if (user.Money < 100)
                {
                    if (user.Money > 10)
                    {
                        var percentage = Convert.ToDecimal(0.8);
                        var gif = user.Money * percentage;
                        user.Money = user.Money + gif;
                    }
                }
            }
            if (user.UserType == USER_TYPE_SUPER_USER)
            {
                if (user.Money > 100)
                {
                    var percentage = Convert.ToDecimal(0.20);
                    var gif = user.Money * percentage;
                    user.Money = user.Money + gif;
                }
            }
            if (user.UserType == USER_TYPE_PREMIUM)
            {
                if (user.Money > 100)
                {
                    var gif = user.Money * 2;
                    user.Money = user.Money + gif;
                }
            }
        }

        public string NormalizeEmail(string email)
        {
            var aux = email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            return string.Join("@", new string[] { aux[0], aux[1] });
        }

        public bool IsDuplicated(User existingUser, User newUser)
        {
            return existingUser.Email.Equals(newUser.Email, StringComparison.CurrentCultureIgnoreCase)
                || existingUser.Phone.Equals(newUser.Phone)
                || (existingUser.Name.Equals(newUser.Name, StringComparison.CurrentCultureIgnoreCase)
                    && existingUser.Address.Equals(newUser.Address, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
