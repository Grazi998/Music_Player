//using Music_Player.DbModels;
using Music_Player.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_Player.DtoMappers
{
    public static class SongDto
    {
        public static Song FromJson(JObject json)
        {
            var id = json["id"].ToObject<int?>();
            var name = json["songname"].ToObject<string>();
            var songlength = json["songlength"].ToObject<int>();
            var artist = json["artist_id"].ToObject<int?>();

            return new Song(id, name, songlength, artist);

        }
    }
}
