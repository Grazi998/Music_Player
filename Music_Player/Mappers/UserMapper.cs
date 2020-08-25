using Music_Player.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_Player.Mappers
{
    public class UserMapper
    {
        public static User FromDatabase(DbModels.MscUser user)
        {
            return new User(user.Id,
                user.Username,
                user.Email,
                user.Password);
        }

        public static DbModels.MscUser ToDatabase(User user)
        {
            return new DbModels.MscUser
            {
                Id = user.ID.HasValue ? user.ID.Value : 0,
                Username = user.username,
                Email = user.email,
                Password = user.password
            };
        }
    }
}
