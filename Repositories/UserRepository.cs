using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherAPI.Models;

namespace WeatherAPI.Repositories
{
    public class UserRepository
    {
        public static User Get(string username, string password)
        {
            
            if(username == null|| password == null)
            {
                return null;
            }
            
            char[] charArray = username.ToCharArray();
            Array.Reverse(charArray);
            var newPassword = new string(charArray);

            
            var users = new List<User>();
            users.Add(new User { Id = 1, Username = username, Password = newPassword, Role = "manager" });

            if(password == newPassword)
            {
                return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
            }

            return null; 
            
        }
    }
}
