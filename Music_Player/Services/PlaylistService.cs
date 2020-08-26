using Music_Player.Models;
using Music_Player.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_Player.Services
{
    public class PlaylistService
    {
        public PlaylistRepository _pr;

        public PlaylistService(PlaylistRepository pr)
        {
            _pr = pr;
        }

        public IEnumerable<Models.Playlist> GetAll()
        {
            return _pr.GetAll();
        }

        public Models.Playlist GetPlaylist(int songid)
        {
            return _pr.GetPlaylist(songid);
        }
        public List<Models.Song> GetSongs(int id)
        {
            return _pr.GetSongs(id);
        }

        public void Add(Playlist_Song playsong)
        {
            _pr.Add(playsong);
        }
    }
}
