using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MusicPlayer.Core.Domain.Models
{
    public class AddedSong
    {
        public Guid song_id { get; set; }
        public Guid playlist_id { get; set; }
        public DateTime addition_date { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        [ForeignKey("song_id")]
        public Song Song { get; set; }
        [ForeignKey("playlist_id")]
        public Playlist Playlist { get; set; }
    }
}
