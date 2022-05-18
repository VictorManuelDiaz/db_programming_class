﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Entities
{
    class Artist_Song
    {
        public int tb_artist_id { get; set; }
        public int tb_song_id { get; set; }
        public string is_author { get; set; }
        public string is_performer { get; set; }
        public string is_guest { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int created_by { get; set; }
        public int updated_by { get; set; }
    }
}
