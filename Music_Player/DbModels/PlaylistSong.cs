using System;
using System.Collections.Generic;

namespace Music_Player.DbModels
{
    public partial class PlaylistSong
    {
        public int PlaylistId { get; set; }
        public int SongId { get; set; }

        public virtual Playlist Playlist { get; set; }
        public virtual Song Song { get; set; }
    }
}
