using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicPlayer.Core.Domain.Models;

namespace MusicPlayer.Adaptors.SQLServerDataAccess.Entities
{
    public class EPlaylist : IEntityTypeConfiguration<Playlist>
    {
        public void Configure(EntityTypeBuilder<Playlist> builder)
        {
            builder.ToTable("tb_playlist");

            builder.HasKey(pl => pl.playlist_id);

            builder
                .HasMany(pl => pl.AddedSongs)
                .WithOne(a => a.Playlist);
        }
    }
}
