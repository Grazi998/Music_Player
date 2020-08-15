using System;
using System.Collections.Generic;

namespace Music_Player.DbModels
{
    public partial class Song
    {
        public Song()
        {
            PlaylistSong = new HashSet<PlaylistSong>();
        }

        public int Id { get; set; }
        public string Songname { get; set; }
        public int Songlength { get; set; }
        public int ArtistId { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual ICollection<PlaylistSong> PlaylistSong { get; set; }
    }
}
