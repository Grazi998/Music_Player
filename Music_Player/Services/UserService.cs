using Music_Player.Models;
using Music_Player.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_Player.Services
{
    public class UserService
    {
        public UserRepository _ur;

        public UserService(UserRepository ur)
        {
            _ur = ur;
        }

        public IEnumerable<User> GetAll()
        {
            return _ur.GetAll();
        }

        public User GetByName(string uname)
        {
            return _ur.GetByName(uname);
        }

        //public IEnumerable<TaskToDo> GetTasks(int id)
        //{
        //    return _adminRepository.GetTasks(id);
        //}
        public async Task<User> Getuser(int id)
        {
            return await _ur.Getuser(id);
        }

        public IEnumerable<Models.Playlist> GetAllPlaylists(string user)
        {
            return _ur.GetAllPlaylists(user);
        }

        //public void UserEdit(User user)
        //{
        //    _ur.UserEdit(user);
        //}

        public void DeleteUser(int id)
        {
            _ur.DeleteUser(id);
        }
    }
}
