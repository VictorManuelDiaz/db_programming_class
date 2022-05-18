using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Entities
{
    class Artist
    {
        public int tb_artist_id { get; set; }
        public string alias { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string type { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int created_by { get; set; }
        public int updated_by { get; set; }
        public List<Artist_Song> Songs { get; set; }
        public List<Artist_Album> Albums { get; set; }
    }
}
