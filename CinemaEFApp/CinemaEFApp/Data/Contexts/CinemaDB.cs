using System;
using System.Collections.Generic;
using System.Text;

using CinemaEFApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaEFApp.Data.Contexts
{
    class CinemaDB : DbContext
    {
        public DbSet<Movie> movies { get; set; }
        public DbSet<Language> languages { get; set; }
        public DbSet<Clasification> clasifications { get; set; }
        public DbSet<Genre> genres { get; set; }
        public DbSet<Movie_Language> movie_languages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new MovieConfig());
            modelBuilder.ApplyConfiguration(new LanguageConfig());
            modelBuilder.ApplyConfiguration(new ClasificationConfig());
            modelBuilder.ApplyConfiguration(new GenreConfig());
            modelBuilder.ApplyConfiguration(new Movie_LaguageConfig());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string server_name = @"DESKTOP-VC8JTUE\SQLEXPRESS";
            //Nombre del servidor SQL server
            string database_name = "cinema";
            //Nombre de la base de datos

            optionsBuilder.UseSqlServer(
                $"Data Source={server_name};Initial Catalog={database_name};Integrated Security=True;"
            );
        }
    }
}

