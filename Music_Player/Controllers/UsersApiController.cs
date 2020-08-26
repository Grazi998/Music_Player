using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Music_Player.DtoMappers;
using Music_Player.Models;
using Music_Player.Services;
using Newtonsoft.Json.Linq;

namespace Music_Player.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UsersApiController : ControllerBase
    {
        private UserService _us;
        public UsersApiController(UserService us)
        {
            _us = us;
        }

        [HttpGet("allusers")]
        public ActionResult<List<User>> Get()
        {
            return _us.GetAll().ToList();
        }

        [HttpGet("allplaylists/{user}")]
        public ActionResult<List<Playlist>> GetPlaylists(string user)
        {
            return _us.GetAllPlaylists(user).ToList();
        }

        //[HttpGet("usertasks/{id}")]
        //public ActionResult<List<TaskToDo>> GetTasks(int id)
        //{
        //    return _adminService.GetTasks(id).ToList();
        //}

        [HttpGet("profil/{id}")]
        public async Task<ActionResult<User>> Getuser(int id)
        {
            return await _us.Getuser(id);
        }

        //[HttpPut("useredit")]
        //public void UserEdit([FromBody] JObject json)
        //{
        //    var usr = UserDto.FromJson(json);
        //    _us.UserEdit(usr);
        //}

        [HttpDelete("delete/{id}")]
        public void Delete(int id)
        {
            _us.DeleteUser(id);
        }
    }
}
