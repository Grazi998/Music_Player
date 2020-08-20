using Music_Player.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_Player.DtoMappers
{
    public static class ArtistDto
    {
        public static Artist FromJson(JObject json)
        {
            var id = json["id"].ToObject<int?>();
            var name = json["artistname"].ToObject<string>();

            return new Artist(id, name);

        }
    }
}
