using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Music_Player.DbModels;
using Music_Player.Models;
using Music_Player.Services;

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
    }
}
