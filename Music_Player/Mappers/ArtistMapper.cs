using Music_Player.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_Player.Mappers
{
    public class ArtistMapper
    {
        public static Artist FromDatabase(DbModels.Artist artist)
        {
            return new Artist(
                artist.Id,
                artist.Artistname
                );
        }

        public static DbModels.Artist ToDatabase(Artist artist)
        {

            return new DbModels.Artist
            {
                Id = artist.ID.HasValue ? artist.ID.Value : 0,
                Artistname = artist.name
            };
        }
    }
}
