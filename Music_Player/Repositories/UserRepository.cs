using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Music_Player.DbModels;
using Music_Player.Mappers;
using Music_Player.Models;
using System;
using System.Collections;
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

        public Models.User GetByName(string uname)
        {
            var result = _dbContext.MscUser.Where(x => x.Username.Equals(uname)).FirstOrDefault();
            return UserMapper.FromDatabase(result);

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
            if (_dbContext.Playlist.Where(x => x.MscUserId.Equals(userid.Id)).FirstOrDefault() != null)
            {
               var data = _dbContext.Playlist.Where(x => x.MscUserId == userid.Id).Select(x => PlaylistMapper.FromDatabase(x));
               return data;
            }
            else
            {
                return Enumerable.Empty<Models.Playlist>();
            }
            //var data =   _dbContext.Playlist.Where(x => x.MscUserId == userid.Id).Select(x => PlaylistMapper.FromDatabase(x));
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

                var playlist = _dbContext.Playlist.Where(x => x.MscUserId.Equals(id)).FirstOrDefault();
                playlist.MscUserId = null;
                while (_dbContext.ListSong.Where(x => x.PlaylistId.Equals(playlist.Id)).FirstOrDefault() != null)
                {
                    var couple = _dbContext.ListSong.Where(x => x.PlaylistId.Equals(playlist.Id)).FirstOrDefault();
                    couple.SongId = null;
                    couple.PlaylistId = null;
                    _dbContext.ListSong.Remove(couple);
                    _dbContext.SaveChanges();
                }
                Console.WriteLine("\nConn with songs deleted");
                _dbContext.Playlist.Remove(playlist);
                _dbContext.SaveChanges();
            }
            Console.WriteLine("\nPlaylists deleted");
            var user = _dbContext.MscUser.Where(x => x.Id == id).FirstOrDefault();
            _dbContext.MscUser.Remove(user);
            _dbContext.SaveChanges();
            Console.WriteLine("\nUser deleted");
        }
    }
}
