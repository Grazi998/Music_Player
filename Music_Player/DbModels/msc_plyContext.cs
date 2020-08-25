using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Music_Player.DbModels
{
    public partial class msc_plyContext : DbContext
    {
        public msc_plyContext()
        {
        }

        public msc_plyContext(DbContextOptions<msc_plyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artist> Artist { get; set; }
        public virtual DbSet<MscAdmin> MscAdmin { get; set; }
        public virtual DbSet<MscUser> MscUser { get; set; }
        public virtual DbSet<Playlist> Playlist { get; set; }
        public virtual DbSet<PlaylistSong> PlaylistSong { get; set; }
        public virtual DbSet<Song> Song { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=msc_ply;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>(entity =>
            {
                entity.ToTable("artist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Artistname)
                    .IsRequired()
                    .HasColumnName("artistname")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MscAdmin>(entity =>
            {
                entity.ToTable("msc_admin");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MscUser>(entity =>
            {
                entity.ToTable("msc_user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Playlist>(entity =>
            {
                entity.ToTable("playlist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MscUserId).HasColumnName("msc_user_id");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.MscUser)
                    .WithMany(p => p.Playlist)
                    .HasForeignKey(d => d.MscUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("playlist_msc_user_id_fk");
            });

            modelBuilder.Entity<PlaylistSong>(entity =>
            {
                entity.HasKey(e => new { e.PlaylistId, e.SongId })
                    .HasName("playlist_song_pk");

                entity.ToTable("playlist_song");

                entity.Property(e => e.PlaylistId).HasColumnName("playlist_id");

                entity.Property(e => e.SongId).HasColumnName("song_id");

                entity.HasOne(d => d.Playlist)
                    .WithMany(p => p.PlaylistSong)
                    .HasForeignKey(d => d.PlaylistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("playlist_song_playlist_id_fk");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.PlaylistSong)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("playlist_song_song_id_fk");
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.ToTable("song");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ArtistId).HasColumnName("artist_id");

                entity.Property(e => e.Songlength).HasColumnName("songlength");

                entity.Property(e => e.Songname)
                    .IsRequired()
                    .HasColumnName("songname")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Song)
                    .HasForeignKey(d => d.ArtistId)
                    .HasConstraintName("song_artist_id_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
