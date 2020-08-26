using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_Player.Models
{
    public class Playlist_Song
    {
        public int? ID { get; set; }
        public int? SongID { get; set; }
        public int? PlaylistID { get; set; }


        public Playlist_Song(int? id, int? playlistid, int? songid)
        {
            ID = id;
            SongID = songid;
            PlaylistID = playlistid;
        }
    }
}
