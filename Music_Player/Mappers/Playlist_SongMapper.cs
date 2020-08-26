using Music_Player.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_Player.Mappers
{
    public class Playlist_SongMapper
    {
        public static Playlist_Song FromDatabase(DbModels.ListSong ply)
        {
            return new Playlist_Song(
                ply.ListSongId,
                ply.PlaylistId,
                ply.SongId
                );
        }
        public static DbModels.ListSong ToDatabase(Playlist_Song ply)
        {

            return new DbModels.ListSong
            {
                ListSongId = ply.ID.HasValue ? ply.ID.Value : 0,
                PlaylistId = ply.PlaylistID,
                SongId = ply.SongID
            };
        }
    }
}
