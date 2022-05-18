using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaEFApp.Data.Models
{
    class Clasification
    {
        public Guid clasification_id { get; set; }
        public string identifier { get; set; }
        public string description { get; set; }
        public int admitted_age { get; set; }
    }

    class ClasificationConfig : IEntityTypeConfiguration<Clasification>
    {
        public void Configure(EntityTypeBuilder<Clasification> builder)
        {
            builder.ToTable("tb_clasification");
            builder.HasKey(c => c.clasification_id);
        }
    }   
}


