using Music_Player.DbModels;
using Music_Player.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_Player.Repositories
{
    public class PlaylistRepository
    {
        private msc_plyContext _dbContext;

        public PlaylistRepository (msc_plyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Models.Playlist> GetAll()
        {
            return _dbContext.Playlist.Select(x => PlaylistMapper.FromDatabase(x));
        }

        public Models.Playlist GetPlaylist(int songid)
        {
            DbModels.ListSong couple = null;
            if (_dbContext.ListSong.Where(x => x.SongId == songid).FirstOrDefault() != null)
            {
                couple = _dbContext.ListSong.Where(x => x.SongId == songid).FirstOrDefault();
            }
            DbModels.Playlist playlist = null;
            if (couple != null)
            {
                playlist = _dbContext.Playlist.Where(x => x.Id == couple.PlaylistId).FirstOrDefault();
            }
            if (playlist == null)
            {
                return null;
            }
            else
            {
                return PlaylistMapper.FromDatabase(playlist);
            }
        }
        public void Add(Models.Playlist_Song playsong)
        {
            var dbPlaySong = Playlist_SongMapper.ToDatabase(playsong);
            _dbContext.ListSong.Add(dbPlaySong);
            _dbContext.SaveChanges();
        }

        public List<Models.Song> GetSongs(int id)
        {
            List<Models.Song> songs= new List<Models.Song>();
            var couples = _dbContext.ListSong.Where(x => x.PlaylistId == id);
            foreach(ListSong ls in couples)
            {
                var song = _dbContext.Song.Where(x => x.Id == ls.SongId).FirstOrDefault();
                songs.Add(SongMapper.FromDatabase(song));
            }

            return songs;
        }
    }
}
