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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=BlueDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
