using Music_Player.Models;
using Music_Player.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_Player.Services
{
    public class SongService
    {
        private SongRepository _sr;

        public SongService(SongRepository sr)
        {
            _sr = sr;
        }

        public IEnumerable<Models.Song> GetAll()
        {
            return _sr.GetAll();
        }

        public async Task<Song> GetAsync(int id)
        {
            return await _sr.GetAsync(id);
        }

        public void Save(Song song)
        {
            _sr.Save(song);
        }

        public void SongEdit(Song song)
        {
            _sr.SongEdit(song);
        }

        public void SongDelete(int id)
        {
             _sr.SongDelete(id);
        }
    }
}
