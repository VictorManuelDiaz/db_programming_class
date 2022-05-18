using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Entities
{
    class Album
    {
        public int tb_album_id { get; set; }
        public string title { get; set; }
        public string format { get; set; }
        public DateTime copyright_date { get; set; }
        public string identifier { get; set; }
        public string tb_musician_id { get; set; } //Llave foránes tabla músicos
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int created_by { get; set; }
        public int updated_by { get; set; }
        public List<Album_Song> Songs { get; set; }
        public List<Artist_Album> Artists { get; set; }
    }
}
