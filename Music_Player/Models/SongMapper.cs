using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_Player.Models
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
    }
}
