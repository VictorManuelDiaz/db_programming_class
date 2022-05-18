using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Entities
{
    class Song
    {
        public int tb_song_id { get; set; }
        public string title { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int created_by { get; set; }
        public int updated_by { get; set; }
        public List<Album_Song> Albums { get; set; }
        public List<Artist_Song> Artists { get; set; }
        public List<Musician_Song> Musicians { get; set; }
    }
}
