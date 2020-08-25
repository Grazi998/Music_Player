using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_Player.Models
{
    public class Admin
    {
        public int? ID { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public Admin(int? id, string _username, string _password)
        {
            ID = id;
            username = _username;
            password = _password;
        }
    }
}
