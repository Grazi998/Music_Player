using System;
using System.Collections.Generic;

namespace Music_Player.DbModels
{
    public partial class ListSong
    {
        public int ListSongId { get; set; }
        public int? PlaylistId { get; set; }
        public int? SongId { get; set; }

        public virtual Playlist Playlist { get; set; }
        public virtual Song Song { get; set; }
    }
}
