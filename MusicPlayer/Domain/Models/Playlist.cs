using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    class Playlist
    {
        public Guid playlist_id { get; set; }
        public string title { get; set; }
        public string image { get; set; }
        public DateTime creation_date { get; set; }
        public Guid user_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
