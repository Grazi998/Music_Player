using System;
using System.Collections.Generic;

namespace Music_Player.DbModels
{
    public partial class Song
    {
        public Song()
        {
            ListSong = new HashSet<ListSong>();
        }

        public int Id { get; set; }
        public string Songname { get; set; }
        public int Songlength { get; set; }
        public int? ArtistId { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual ICollection<ListSong> ListSong { get; set; }
    }
}
