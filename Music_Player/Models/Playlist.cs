using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_Player.Models
{
    public class Playlist
    {
        public int? ID { get; set; }

        public string title { get; set; }

        public int? userID { get; set; }

        public Playlist(int? id, string _title, int? _userID)
        {
            ID = id;
            title = _title;
            userID = _userID;
        }
    }
}
