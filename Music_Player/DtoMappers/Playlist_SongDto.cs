using Music_Player.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_Player.DtoMappers
{
    public static class Playlist_SongDto
    {
        public static Playlist_Song FromJson(JObject json)
        {
            var id = json["id"].ToObject<int?>();
            var playlistid = json["playlistid"].ToObject<int?>();
            var songid = json["songid"].ToObject<int?>();

            return new Playlist_Song(id, playlistid, songid);

        }
    }
}
