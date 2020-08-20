using Microsoft.EntityFrameworkCore;
using Music_Player.DbModels;
using Music_Player.Mappers;
using Music_Player.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_Player.Repositories
{
    public class SongRepository
    {
        private msc_plyContext _dbContext;

        public SongRepository(msc_plyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Models.Song> GetAll()
        {
            return _dbContext.Song.Select(x => SongMapper.FromDatabase(x));
        }

        public async Task<Models.Song> GetAsync(int id)
        {
            var result = await _dbContext.Song.SingleOrDefaultAsync(x => x.Id == id);
            return SongMapper.FromDatabase(result);
        }

        public void Save(Models.Song song)
        {
            var dbSong = SongMapper.ToDatabase(song);
            _dbContext.Song.Add(dbSong);
            _dbContext.SaveChanges();
        }

        public void SongEdit(Models.Song song)
        {
            var dbSong = SongMapper.ToDatabase(song);
            _dbContext.Song.Update(dbSong);
            _dbContext.SaveChanges();
        }
    }
}
