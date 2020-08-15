using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_Player.Models
{
    public class User
    {
        public int? ID { get; set; }

        public string username { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public User(int? id, string _username, string _email, string _password)
        {
            ID = id;
            username = _username;
            email = _email;
            password = _password;
        }
    }
}
