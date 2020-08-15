using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_Player.Models
{
    public class Artist
    {
        public int? ID { get; set; }
        public string name { get; set; }

        public Artist( int? id, string _name)
        {
            ID = id;
            name = _name;
        }
    }
}
