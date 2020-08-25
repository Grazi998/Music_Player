using System;
using System.Collections.Generic;

namespace Music_Player.DbModels
{
    public partial class MscUser
    {
        public MscUser()
        {
            Playlist = new HashSet<Playlist>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Playlist> Playlist { get; set; }
    }
}
