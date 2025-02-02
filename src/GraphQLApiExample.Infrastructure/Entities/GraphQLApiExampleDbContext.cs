using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GraphQLApiExample.Infrastructure.Entities;

public partial class GraphQLApiExampleDbContext : DbContext
{
    public GraphQLApiExampleDbContext()
    {
    }

    public GraphQLApiExampleDbContext(DbContextOptions<GraphQLApiExampleDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Article { get; set; }

    public virtual DbSet<Comment> Comment { get; set; }

    public virtual DbSet<UserDbo> User { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS01;Database=GraphQLApiExample;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Content)
                .HasMaxLength(8000)
                .IsUnicode(false);
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Article)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Article_User");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Content).HasMaxLength(250);
            entity.Property(e => e.CreationDate).HasColumnType("datetime");

            entity.HasOne(d => d.Article).WithMany(p => p.Comment)
                .HasForeignKey(d => d.ArticleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comment_Article");

            entity.HasOne(d => d.User).WithMany(p => p.Comment)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comment_User");
        });

        modelBuilder.Entity<UserDbo>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Mail)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Pseudo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
