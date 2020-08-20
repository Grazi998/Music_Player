using Music_Player.Models;
using Music_Player.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_Player.Services
{
    public class ArtistService
    {
        private ArtistRepository _ar;

        public ArtistService(ArtistRepository ar)
        {
            _ar = ar;
        }

        public IEnumerable<Models.Artist> GetAll()
        {
            return _ar.GetAll();
        }

        public void Save(Artist artist)
        {
            _ar.Save(artist);
        }

        public async Task DeleteAsync(int id)
        {
            await _ar.DeleteAsync(id);
        }
    }
}
