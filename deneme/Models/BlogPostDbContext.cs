using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace deneme.Models
{
    public partial class BlogPostDbContext : DbContext
    {
        public BlogPostDbContext()
        {
        }

        public BlogPostDbContext(DbContextOptions<BlogPostDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<About> Abouts { get; set; } = null!;
        public virtual DbSet<TblPost> TblPosts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-0V8VD7E\\SQLEXPRESS;Database=BlogPostDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<About>(entity =>
            {
                entity.ToTable("About");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblPost>(entity =>
            {
                entity.ToTable("TBL_Post");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("createdTime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PostResim)
                    .HasMaxLength(255)
                    .HasColumnName("postResim")
                    .IsFixedLength();

                entity.Property(e => e.Title)
                    .HasMaxLength(250)
                    .IsFixedLength();

                entity.Property(e => e.UpdatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedTime")
                    .HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
