using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Music_Player.DbModels;
using Music_Player.Models;
using Music_Player.Models.AuthenticationModel;
using Newtonsoft.Json;

namespace Music_Player.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly msc_plyContext _dbContext;

        public AuthenticationController(msc_plyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult AdminSignin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminSignin([FromForm] RegisterData register)
        {

            var valid = VerifyAdmin(register.Username, register.Password);
            if (valid != null)
            {
                return RedirectToRoute(new
                {
                    controller = "Admin",
                    action = "AdminHome"
                });
            }
            else
            {
                return View("NE VALJA!");

            }

        }


        //METODE ZA AUTENTIKACIJU
        public DbModels.MscAdmin VerifyAdmin(string username, string password)
        {
            var result = _dbContext.MscAdmin.Where(x => (x.Username.Equals(username) && x.Password.Equals(password))).FirstOrDefault();
            if (result == null)
            {
                return null;
            }
            else
            {
                var userInfo = new UserInfo() { Username = result.Username, UserId = result.Id };
                HttpContext.Session.SetString("SessionAdmin", JsonConvert.SerializeObject(userInfo));
                return result;
            }

        }
    }
}
