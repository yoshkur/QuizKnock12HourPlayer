using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QuizKnock12HourPlayer.Models
{
    public partial class qk12hContext : DbContext
    {
        public qk12hContext()
        {
        }

        public qk12hContext(DbContextOptions<qk12hContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Players> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Server=kurata.jp.net;Port=64198;Database=qk12h;User ID=quizknockuser;Password=J1j38B4m;persist security info=True;Enlist=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Players>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("pk_players");

                entity.ToTable("players");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Gotou1).HasColumnName("gotou1");

                entity.Property(e => e.Gotou2).HasColumnName("gotou2");

                entity.Property(e => e.Gotou3).HasColumnName("gotou3");

                entity.Property(e => e.Reset1).HasColumnName("reset1");

                entity.Property(e => e.Reset2).HasColumnName("reset2");

                entity.Property(e => e.Seikai).HasColumnName("seikai");

                entity.Property(e => e.Username).HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
