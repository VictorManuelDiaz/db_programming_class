using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaEFApp.Data.Models
{
    class Movie_Language
    {
        public Guid movie_id { get; set; }
        public Guid language_id { get; set; }
        public Boolean is_audio { get; set; }
        public Boolean is_subtitle { get; set; }
    }

    class Movie_LaguageConfig : IEntityTypeConfiguration<Movie_Language>
    {
        public void Configure(EntityTypeBuilder<Movie_Language> builder)
        {
            builder.ToTable("tb_movie_language");
            builder.HasKey(ml => new { ml.movie_id, ml.language_id });
        }
    }
}



