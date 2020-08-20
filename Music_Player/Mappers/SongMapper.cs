using Music_Player.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_Player.Mappers
{
    public class SongMapper
    {
        public static Song FromDatabase(DbModels.Song song)
        {
            return new Song(
                song.Id,
                song.Songname,
                song.Songlength,
                song.ArtistId
                );
        }
        public static DbModels.Song ToDatabase(Song song)
        {

            return new DbModels.Song
            {
                Id = song.ID.HasValue ? song.ID.Value : 0,
                Songname = song.name,
                Songlength = song.length,
                ArtistId = song.artistID
            };
        }
    }
}
