using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Music_Player.DbModels;
using Music_Player.Mappers;
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

        public IActionResult UserSignIn()
        {

            return View();
        }

        public IActionResult UserSignUp()
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
                return View();

            }

        }

        [HttpPost]
        public IActionResult UserSignIn([FromForm] RegisterData register)
        {
            var valid = VerifyUserSingIn(register.Username, register.Password);
            if (valid != null)
            {
                return RedirectToRoute(new
                {
                    controller = "User",
                    action = "AllSongs"
                });
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        public IActionResult UserSignUp(string username, string email, string password, string passwordConfirmation)
        {
            var valid = VerifyUserSingUp(username, password, passwordConfirmation, email);
            if (valid != null)
            {
                return RedirectToRoute(new
                {
                    controller = "Home",
                    action = "Artists"
                });
            }
            else
            {
                return View();
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

        public DbModels.MscUser VerifyUserSingIn(string username, string password)
        {
            var result = _dbContext.MscUser.Where(x => (x.Username.Equals(username) && x.Password.Equals(password))).FirstOrDefault();
            if (result == null)
            {
                return null;
            }
            else
            {
                var userInfo = new UserInfo() { Username = result.Username, UserId = result.Id };
                HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(userInfo));
                return result;
            }

        }

        public DbModels.MscUser VerifyUserSingUp(string username, string password, string passwordConfirm, string email)
        {
            Console.WriteLine("Username: " + username + " password: " + password + " confirmpassword: " + passwordConfirm + " email: " + email);
            if (username == null || password == null || passwordConfirm == null || email == null || password != passwordConfirm)
            {
                Console.WriteLine("Error. Missing input values!");
                return null;
            }
            else
            {
                var result = _dbContext.MscUser.Where(x => x.Username.Equals(username)).FirstOrDefault();
                if (result == null)
                {
                    Models.User user = new Models.User(null, username, email, password);
                    var dbUser = UserMapper.ToDatabase(user);
                    _dbContext.MscUser.Add(dbUser);
                    _dbContext.SaveChanges();
                    var result2 = _dbContext.MscUser.Where(x => x.Username.Equals(username)).FirstOrDefault();
                    Console.WriteLine("Result user: " + result2);
                    var userInfo = new UserInfo() { Username = result2.Username, UserId = result2.Id };
                    HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(userInfo));
                    return result2;
                }
                else
                {
                    Console.WriteLine("User exists!");
                    return null;
                }
            }

        }
    }
}
