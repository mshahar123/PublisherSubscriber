using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PublisherSubscriber.Models
{
    public partial class SU_DBContext : DbContext
    {
        public SU_DBContext()
        {
        }

        public SU_DBContext(DbContextOptions<SU_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ContentTbl> ContentTbls { get; set; } = null!;
        public virtual DbSet<LoginTbl> LoginTbls { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContentTbl>(entity =>
            {
                entity.HasKey(e => e.ContentId)
                    .HasName("PK__Content___2907A81ED2742EC1");

                entity.ToTable("Content_tbl");

                entity.Property(e => e.ContentId).ValueGeneratedNever();

                entity.Property(e => e.ContentName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContentType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PersonCity)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PersonGender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PersonName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PersonQualification)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Subscribe)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnSubscribe)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LoginTbl>(entity =>
            {
                entity.ToTable("Login_tbl");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
