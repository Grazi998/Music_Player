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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Music_Player.Controllers
{
    [Route("api/artist")]
    [ApiController]
    public class ArtistApiController : ControllerBase
    {
        public ArtistService _as;

        public ArtistApiController(ArtistService ars)
        {
            _as = ars;
        }

        [HttpGet]
        public ActionResult<List<Models.Artist>> Get()
        {
            return _as.GetAll().ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Artist>> GetOne(int id)
        {
            return await _as.GetAsync(id);
        }

        [HttpPost("addArtist")]
        public ActionResult Save([FromBody] JObject json)
        {
            var ar = JObject.Parse(json.ToString());
            //taskCh["userid"] = userInfo.UserId;
            //Console.WriteLine("Ovo je task: " + taskCh);
            var artist = ArtistDto.FromJson(ar);
            //var task = TaskDto.FromJson(json);
            Console.WriteLine(artist);
            _as.Save(artist);
            return Ok();
        }

        [HttpPut("editArtist")]
        public void ArtistEdit([FromBody] JObject json)
        {
            var art = ArtistDto.FromJson(json);
            _as.ArtistEdit(art);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _as.DeleteAsync(id);

        }
    }
}
