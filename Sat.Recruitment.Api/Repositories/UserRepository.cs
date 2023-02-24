using Sat.Recruitment.Api.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Sat.Recruitment.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        public List<User> users = new List<User>();

        string path = Directory.GetCurrentDirectory() + "/Files/Users.txt";

        public List<User> ReadUsersFromFile()
        {
            FileStream fileStream = new FileStream(path, FileMode.Open);
            StreamReader reader = new StreamReader(fileStream);

            while (reader.Peek() >= 0)
            {
                var line = reader.ReadLineAsync().Result;
                var user = new User
                {
                    Name = line.Split(',')[0].ToString(),
                    Email = line.Split(',')[1].ToString(),
                    Phone = line.Split(',')[2].ToString(),
                    Address = line.Split(',')[3].ToString(),
                    UserType = line.Split(',')[4].ToString(),
                    Money = decimal.Parse(line.Split(',')[5].ToString()),
                };
                users.Add(user);
            }
            reader.Close();

            return users;
        }

        public void SaveUser(User user)
        {
            try
            {
                var line = $"{user.Name},{user.Email},{user.Phone},{user.Address},{user.UserType},{user.Money}";

                using (StreamWriter writer = new StreamWriter(path, append: true))
                {
                    writer.WriteLine(line);
                }

            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
        }
    }
}
