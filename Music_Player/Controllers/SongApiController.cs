using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Music_Player.DtoMappers;
//using Music_Player.DbModels;
using Music_Player.Models;
using Music_Player.Services;
using Newtonsoft.Json.Linq;

namespace Music_Player.Controllers
{
    [Route("api/song")]
    [ApiController]
    public class SongApiController : ControllerBase
    {
        public SongService _ss;

        public SongApiController(SongService ss)
        {
            _ss = ss;
        }

        [HttpGet]
        public ActionResult<List<Song>> Get()
        {
            return _ss.GetAll().ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetOne(int id)
        {
            return await _ss.GetAsync(id);
        }

        [HttpPost("newSong")]
        public ActionResult Save([FromBody] JObject json)
        {
            var s = JObject.Parse(json.ToString());
            var song = SongDto.FromJson(s);
            //Console.WriteLine(song);
            _ss.Save(song);
            return Ok();
        }

        [HttpPut("songedit")]
        public void SongEdit([FromBody] JObject json)
        {
            var song = SongDto.FromJson(json);
            _ss.SongEdit(song);
        }

        [HttpDelete("delete/{id}")]
        public void Delete(int id)
        {
            _ss.SongDelete(id);

        }

    }
}
