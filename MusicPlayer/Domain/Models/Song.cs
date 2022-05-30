using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    class Song
    {
        public Guid song_id { get; set; }
        public string title { get; set; }
        public string image { get; set; }
        public TimeSpan length { get; set; }
        public string artist { get; set; }
        public string album { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
