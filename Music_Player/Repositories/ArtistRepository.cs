using Microsoft.EntityFrameworkCore;
using Music_Player.DbModels;
using Music_Player.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_Player.Repositories
{
    public class ArtistRepository
    {
        private msc_plyContext _dbContext;

        public ArtistRepository(msc_plyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Models.Artist> GetAll()
        {
            return _dbContext.Artist.Select(x => ArtistMapper.FromDatabase(x));
        }

        public void Save(Models.Artist artist)
        {
            var dbArtist = ArtistMapper.ToDatabase(artist);
            _dbContext.Artist.Add(dbArtist);
            _dbContext.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _dbContext.Artist.SingleAsync(x => x.Id == id);
            var art = ArtistMapper.FromDatabase(result);
            _dbContext.Artist.Remove(result);
            _dbContext.SaveChanges();


        }
    }
}
