using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicPlayer.Core.Domain.Models;

namespace MusicPlayer.Adaptors.SQLServerDataAccess.Entities
{
    public class EAddedSong : IEntityTypeConfiguration<AddedSong>
    {
        public void Configure(EntityTypeBuilder<AddedSong> builder)
        {
            builder.ToTable("tb_added_song");

            builder.HasKey(a => new { a.playlist_id, a.song_id });

            builder
                .HasOne(a => a.Song)
                .WithMany(s => s.AddedSongs);

            builder
                .HasOne(a => a.Playlist)
                .WithMany(p => p.AddedSongs);
        }
    }
}
