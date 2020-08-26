using Music_Player.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_Player.Mappers
{
    public class PlaylistMapper
    {
        public static Playlist FromDatabase(DbModels.Playlist ply)
        {
            return new Playlist(
                ply.Id,
                ply.Title,
                ply.MscUserId
                );
        }
        public static DbModels.Playlist ToDatabase(Playlist ply)
        {

            return new DbModels.Playlist
            {
                Id = ply.ID.HasValue ? ply.ID.Value : 0,
                Title = ply.title,
                MscUserId = ply.userID
            };
        }
    }
}
