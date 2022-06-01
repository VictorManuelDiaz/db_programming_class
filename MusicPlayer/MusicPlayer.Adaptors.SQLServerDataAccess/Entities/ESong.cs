using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicPlayer.Core.Domain.Models;

namespace MusicPlayer.Adaptors.SQLServerDataAccess.Entities
{
    public class ESong : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.ToTable("tb_song");

            builder.HasKey(s => s.song_id);

            builder
                .HasMany(s => s.AddedSongs)
                .WithOne(a => a.Song);
        }
    }
}
