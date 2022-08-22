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

        public virtual DbSet<TblPost> TblPosts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-HRH373GG\\SQLEXPRESS;  Database=BlogPostDb; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
