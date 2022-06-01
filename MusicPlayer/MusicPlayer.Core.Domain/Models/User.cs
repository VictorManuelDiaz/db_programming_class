using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPlayer.Core.Domain.Models
{
    public class User
    {
        public Guid user_id { get; set; }
        public string name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public Boolean is_active { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public List<Playlist> Playlists { get; set; }
    }
}
