using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Music_Player.Models;
using Newtonsoft.Json;
using static Music_Player.Startup;

namespace Music_Player.Controllers
{
    public class AdminController : Controller
    {
        [SessionAdminTimeout]
        public IActionResult AdminHome()
        {
            var userInfo = JsonConvert.DeserializeObject<UserInfo>(HttpContext.Session.GetString("SessionAdmin"));
            ViewBag.user = userInfo.Username;
            return View();


        }
    }
}
