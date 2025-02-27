﻿using System;
using System.Collections.Generic;
using CRUDAPI.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace CRUDAPI.DAL.DBContext;

public partial class blogContext : DbContext
{
    

    public blogContext(DbContextOptions<blogContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=blog;Username=postgres;Password=123456789");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("posts_pkey");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.IsPublished).HasDefaultValue(true);
 

            /*entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Posts)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("created_by_fkey");*/
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
