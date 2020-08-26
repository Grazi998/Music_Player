using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Music_Player.Models;
using Newtonsoft.Json;
using static Music_Player.Startup;

namespace Music_Player.Controllers
{
    public class UserController : Controller
    {
        [SessionUserTimeout]
        public IActionResult AllSongs()
        {
            var userInfo = JsonConvert.DeserializeObject<UserInfo>(HttpContext.Session.GetString("SessionUser"));
            ViewBag.user = userInfo.Username;
            return View();
        }
        [SessionUserTimeout]
        public IActionResult Playlists()
        {
            var userInfo = JsonConvert.DeserializeObject<UserInfo>(HttpContext.Session.GetString("SessionUser"));
            ViewBag.user = userInfo.Username;
            return View();
        }
    }
}
