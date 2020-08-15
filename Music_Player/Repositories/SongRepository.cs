using Music_Player.DbModels;
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
    }
}
