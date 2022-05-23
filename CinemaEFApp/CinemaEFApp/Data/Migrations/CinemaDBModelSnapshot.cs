﻿// <auto-generated />
using System;
using CinemaEFApp.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CinemaEFApp.Data.Migrations
{
    [DbContext(typeof(CinemaDB))]
    partial class CinemaDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("CinemaEFApp.Data.Models.Clasification", b =>
                {
                    b.Property<Guid>("clasification_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("admitted_age")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("identifier")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("clasification_id");

                    b.ToTable("tb_clasification");
                });

            modelBuilder.Entity("CinemaEFApp.Data.Models.Genre", b =>
                {
                    b.Property<Guid>("genre_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("genre_id");

                    b.ToTable("tb_genre");
                });

            modelBuilder.Entity("CinemaEFApp.Data.Models.Language", b =>
                {
                    b.Property<Guid>("language_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("abbreviation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("language_id");

                    b.ToTable("tb_language");
                });

            modelBuilder.Entity("CinemaEFApp.Data.Models.Movie", b =>
                {
                    b.Property<Guid>("movie_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("clasification_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("distribution_title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("genre_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("is_on_billboard")
                        .HasColumnType("bit");

                    b.Property<TimeSpan>("length")
                        .HasColumnType("time");

                    b.Property<string>("original_title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("premiere_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("production_year")
                        .HasColumnType("int");

                    b.Property<string>("summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("movie_id");

                    b.HasIndex("clasification_id");

                    b.HasIndex("genre_id");

                    b.ToTable("tb_movie");
                });

            modelBuilder.Entity("CinemaEFApp.Data.Models.Movie_Language", b =>
                {
                    b.Property<Guid>("movie_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("language_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("is_audio")
                        .HasColumnType("bit");

                    b.Property<bool>("is_subtitle")
                        .HasColumnType("bit");

                    b.HasKey("movie_id", "language_id");

                    b.HasIndex("language_id");

                    b.ToTable("tb_movie_language");
                });

            modelBuilder.Entity("CinemaEFApp.Data.Models.Movie", b =>
                {
                    b.HasOne("CinemaEFApp.Data.Models.Clasification", "clasification")
                        .WithMany()
                        .HasForeignKey("clasification_id");

                    b.HasOne("CinemaEFApp.Data.Models.Genre", "genre")
                        .WithMany()
                        .HasForeignKey("genre_id");

                    b.Navigation("clasification");

                    b.Navigation("genre");
                });

            modelBuilder.Entity("CinemaEFApp.Data.Models.Movie_Language", b =>
                {
                    b.HasOne("CinemaEFApp.Data.Models.Language", "language")
                        .WithMany()
                        .HasForeignKey("language_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinemaEFApp.Data.Models.Movie", "movie")
                        .WithMany()
                        .HasForeignKey("movie_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("language");

                    b.Navigation("movie");
                });
#pragma warning restore 612, 618
        }
    }
}