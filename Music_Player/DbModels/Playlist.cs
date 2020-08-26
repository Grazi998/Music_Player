using System;
using System.Collections.Generic;

namespace Music_Player.DbModels
{
    public partial class Playlist
    {
        public Playlist()
        {
            ListSong = new HashSet<ListSong>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? MscUserId { get; set; }

        public virtual MscUser MscUser { get; set; }
        public virtual ICollection<ListSong> ListSong { get; set; }
    }
}
