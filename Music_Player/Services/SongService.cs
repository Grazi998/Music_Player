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
    }
}
