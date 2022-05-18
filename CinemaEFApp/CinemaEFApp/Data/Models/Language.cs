using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaEFApp.Data.Models
{
    class Language
    {
        public Guid language_id { get; set; }
        public string name { get; set; }
        public string abbreviation { get; set; }
    }

    class LanguageConfig : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("tb_language");
            builder.HasKey(l => l.language_id);
        }
    }
}


