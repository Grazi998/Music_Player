using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_Player.Models
{
    public class Song
    {
        public int? ID { get; set; }
        public string name { get; set; }
        public int length { get; set; }
        public int artistID { get; set; }

        public Song(int? id, string _name, int _length, int _artistID)
        {
            ID = id;
            name = _name;
            length = _length;
            artistID = _artistID;
        }
    }
}
