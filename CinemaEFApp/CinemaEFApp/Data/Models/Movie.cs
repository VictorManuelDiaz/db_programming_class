using System;
using System.Collections.Generic;
using System.Text;


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CinemaEFApp.Data.Models
{
    class Movie
    {
        public Guid movie_id { get; set; }
        public string distribution_title { get; set; }
        public string original_title { get; set; }
        public int production_year { get; set; }
        public TimeSpan length { get; set; }
        public DateTime premiere_date { get; set; }
        public string summary { get; set; }
        public Boolean is_on_billboard { get; set; }
        public Genre genre { get; set; } = null!;
        public Clasification clasification  { get; set; } = null!;
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    class MovieConfig : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("tb_movie");
            builder.HasKey(m => m.movie_id);
        }
    }
}

