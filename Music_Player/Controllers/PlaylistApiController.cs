using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Music_Player.DbModels;
using Music_Player.DtoMappers;
using Music_Player.Models;
using Music_Player.Services;
using Newtonsoft.Json.Linq;

namespace Music_Player.Controllers
{
    [Route("api/playlist")]
    [ApiController]
    public class PlaylistApiController : ControllerBase
    {
        public PlaylistService _ps;

        public PlaylistApiController(PlaylistService ps)
        {
            _ps = ps;
        }

        [HttpGet]
        public ActionResult<List<Models.Playlist>> Get()
        {
            return _ps.GetAll().ToList();
        }

        [HttpGet("getplaylistbysong/{songid}")]
        public ActionResult<Models.Playlist> GetPlaylistBySong(int songid)
        {
            return _ps.GetPlaylist(songid);
        }

        [HttpGet("getsongsinplaylist/{id}")]
        public ActionResult<List<Models.Song>> GetSongsInPlaylist(int id)
        {
            return _ps.GetSongs(id);
        }

        [HttpPost("addtoplaylist")]
        public ActionResult Add([FromBody] JObject json)
        {
            var s = JObject.Parse(json.ToString());
            var song = Playlist_SongDto.FromJson(s);
            //Console.WriteLine(song);
            _ps.Add(song);
            return Ok();
        }
    }
}
