using System;
using System.Collections.Generic;
using BlueAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlueAPI.Data;

public partial class BlueDB : DbContext
{
    public BlueDB()
    {
    }

    public BlueDB(DbContextOptions<BlueDB> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Product { get; set; }

    public virtual DbSet<Status> Status { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=BlueDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PKProduct");

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(7, 2)");

            entity.HasOne(d => d.Status).WithMany(p => p.Product)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKStatusProductStatusId");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PKStatus");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
