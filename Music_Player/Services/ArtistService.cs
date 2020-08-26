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

        public async Task<Artist> GetAsync(int id)
        {
            return await _ar.GetAsync(id);
        }

        public void Save(Artist artist)
        {
            _ar.Save(artist);
        }

        public void ArtistEdit(Artist art)
        {
            _ar.ArtistEdit(art);
        }

        public async Task DeleteAsync(int id)
        {
            await _ar.DeleteAsync(id);
        }
    }
}
