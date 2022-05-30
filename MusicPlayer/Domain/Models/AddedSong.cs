using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    class AddedSong
    {
        public Guid song_id { get; set; }
        public Guid playlist_id { get; set; }
        public DateTime addition_date { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
