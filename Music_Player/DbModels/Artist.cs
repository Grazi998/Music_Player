using System;
using System.Collections.Generic;

namespace Music_Player.DbModels
{
    public partial class Artist
    {
        public Artist()
        {
            Song = new HashSet<Song>();
        }

        public int Id { get; set; }
        public string Artistname { get; set; }

        public virtual ICollection<Song> Song { get; set; }
    }
}
