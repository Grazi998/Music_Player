using System;
using System.Collections.Generic;

namespace Music_Player.DbModels
{
    public partial class Playlist
    {
        public Playlist()
        {
            PlaylistSong = new HashSet<PlaylistSong>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int MscUserId { get; set; }

        public virtual MscUser MscUser { get; set; }
        public virtual ICollection<PlaylistSong> PlaylistSong { get; set; }
    }
}
