using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using MusicPlayer.Core.Domain.Models;

using MusicPlayer.Adaptors.SQLServerDataAccess.Entities;

using MusicPlayer.Adaptors.SQLServerDataAccess.Utils;

namespace MusicPlayer.Adaptors.SQLServerDataAccess.Contexts
{
    public class PlaylistDB : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<AddedSong> AddedSongs { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new EUser());
            builder.ApplyConfiguration(new EPlaylist());
            builder.ApplyConfiguration(new ESong());
            builder.ApplyConfiguration(new EAddedSong());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(GlobalSetting.SqlServerConnectionString);
        }
    }
}


