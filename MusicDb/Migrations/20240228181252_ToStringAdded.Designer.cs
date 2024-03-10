﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicDb;

#nullable disable

namespace MusicDb.Migrations
{
    [DbContext(typeof(Music2Context))]
    [Migration("20240228181252_ToStringAdded")]
    partial class ToStringAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MusicDb.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id")
                        .HasName("PK__artists__3214EC073DB9BB10");

                    b.ToTable("artists", (string)null);
                });

            modelBuilder.Entity("MusicDb.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime")
                        .HasColumnName("date");

                    b.Property<int>("Duration")
                        .HasColumnType("int")
                        .HasColumnName("duration");

                    b.Property<int?>("Rating")
                        .HasColumnType("int")
                        .HasColumnName("rating");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("title");

                    b.Property<int>("Weight")
                        .HasColumnType("int")
                        .HasColumnName("weight");

                    b.HasKey("Id")
                        .HasName("PK__songs__3214EC07E497E6A7");

                    b.ToTable("songs", (string)null);
                });

            modelBuilder.Entity("MusicDb.SongArtist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<int>("SongId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__song_art__3214EC0786299686");

                    b.HasIndex("ArtistId");

                    b.HasIndex("SongId");

                    b.ToTable("song_artists", (string)null);
                });

            modelBuilder.Entity("MusicDb.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("email");

                    b.Property<byte>("IsBanned")
                        .HasColumnType("tinyint")
                        .HasColumnName("isBanned");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("login");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("password");

                    b.HasKey("Id")
                        .HasName("PK__tmp_ms_x__3214EC0778DBA7BF");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("MusicDb.SongArtist", b =>
                {
                    b.HasOne("MusicDb.Artist", "Artist")
                        .WithMany("SongArtists")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_artistId");

                    b.HasOne("MusicDb.Song", "Song")
                        .WithMany("SongArtists")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_songId");

                    b.Navigation("Artist");

                    b.Navigation("Song");
                });

            modelBuilder.Entity("MusicDb.Artist", b =>
                {
                    b.Navigation("SongArtists");
                });

            modelBuilder.Entity("MusicDb.Song", b =>
                {
                    b.Navigation("SongArtists");
                });
#pragma warning restore 612, 618
        }
    }
}