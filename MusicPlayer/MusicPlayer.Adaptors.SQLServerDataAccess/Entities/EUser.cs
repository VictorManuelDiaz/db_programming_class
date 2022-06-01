using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicPlayer.Core.Domain.Models;

namespace MusicPlayer.Adaptors.SQLServerDataAccess.Entities
{
    public class EUser : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("tb_user");

            builder.HasKey(u => u.user_id);

            builder
                .HasMany(u => u.Playlists)
                .WithOne(pl => pl.User);
        }
    }
}

