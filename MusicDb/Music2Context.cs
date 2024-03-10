using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MusicDb;

public partial class Music2Context : DbContext
{
    public Music2Context()
    {
    }

    public Music2Context(DbContextOptions<Music2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Artist> Artists { get; set; }

    public virtual DbSet<Song> Songs { get; set; }

    public virtual DbSet<SongArtist> SongArtists { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\.;Initial Catalog=music2;Integrated Security=True;Encrypt=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__artists__3214EC073DB9BB10");

            entity.ToTable("artists");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Song>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__songs__3214EC07E497E6A7");

            entity.ToTable("songs");

            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
            entity.Property(e => e.Weight).HasColumnName("weight");
        });

        modelBuilder.Entity<SongArtist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__song_art__3214EC0786299686");

            entity.ToTable("song_artists");

            entity.HasOne(d => d.Artist).WithMany(p => p.SongArtists)
                .HasForeignKey(d => d.ArtistId)
                .HasConstraintName("fk_artistId");

            entity.HasOne(d => d.Song).WithMany(p => p.SongArtists)
                .HasForeignKey(d => d.SongId)
                .HasConstraintName("fk_songId");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC0778DBA7BF");

            entity.ToTable("users");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.IsBanned).HasColumnName("isBanned");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
