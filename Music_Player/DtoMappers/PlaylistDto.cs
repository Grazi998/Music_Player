using Music_Player.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_Player.DtoMappers
{
    public class PlaylistDto
    {
        public static Playlist FromJson(JObject json)
        {
            var id = json["id"].ToObject<int?>();
            var title = json["title"].ToObject<string>();
            var mscuserid = json["mscuserid"].ToObject<int?>();

            return new Playlist(id, title, mscuserid);

        }
    }
}
