using Microsoft.EntityFrameworkCore;
using Music_Player.DbModels;
using Music_Player.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Music_Player.Repositories
{
    public class UserRepository
    {
        private readonly msc_plyContext _dbContext;

        public UserRepository(msc_plyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Models.User> GetAll()
        {

            return _dbContext.MscUser.Select(x => UserMapper.FromDatabase(x));

        }

        public async Task<Models.User> Getuser(int id)
        {
            var result = await _dbContext.MscUser.SingleOrDefaultAsync(x => x.Id == id);
            return UserMapper.FromDatabase(result);
        }

        public IEnumerable<Models.Playlist> GetAllPlaylists(string user)
        {
            var userid = _dbContext.MscUser.Where(x => x.Username == user).FirstOrDefault();
            Console.WriteLine("User -- " + userid.Username.ToString() + " " + user);
        
            var data =   _dbContext.Playlist.Where(x => x.MscUserId == userid.Id).Select(x => PlaylistMapper.FromDatabase(x));
            Console.WriteLine(data);

            return data;
        }

        //public void UserEdit(Models.User user)
        //{
        //    var dbUser = UserMapper.ToDatabase(user);
        //    _dbContext.MscUser.Update(dbUser);
        //    _dbContext.SaveChanges();
        //}

        public void DeleteUser(int id)
        {
            while (_dbContext.Playlist.Where(x => x.MscUserId.Equals(id)).FirstOrDefault() != null)
            {

                var task = _dbContext.Playlist.Where(x => x.MscUserId.Equals(id)).FirstOrDefault();
                task.MscUserId = null;
                _dbContext.SaveChanges();
            }
            var user = _dbContext.MscUser.Where(x => x.Id == id).FirstOrDefault();
            _dbContext.MscUser.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}
