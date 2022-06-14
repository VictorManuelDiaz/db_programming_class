using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MusicPlayer.Core.Domain.Models
{
    public class Song
    {
        public Guid song_id { get; set; }
        public string title { get; set; }
        public string image { get; set; }
        public TimeSpan length { get; set; }
        [NotMapped]
        public string length_str { get; set; }
        public string artist { get; set; }
        public string album { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public List<AddedSong> AddedSongs { get; set; }
    }
}
