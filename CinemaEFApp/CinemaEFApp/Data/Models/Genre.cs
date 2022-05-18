using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaEFApp.Data.Models
{
    class Genre
    {
        public Guid genre_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    class GenreConfig : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("tb_genre");
            builder.HasKey(g => g.genre_id);
        }
    }
}


