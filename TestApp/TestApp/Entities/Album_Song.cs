﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Entities
{
    class Album_Song
    {
        public int tb_album_id { get; set; }
        public int tb_song_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int created_by { get; set; }
        public int updated_by { get; set; }
    }
}
