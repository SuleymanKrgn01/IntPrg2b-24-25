using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CookSite.Models;

public partial class CookSiteContext : DbContext
{
    public CookSiteContext()
    {
    }

    public CookSiteContext(DbContextOptions<CookSiteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<CookType> CookTypes { get; set; }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<MediaType> MediaTypes { get; set; }

    public virtual DbSet<Medium> Media { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("data source=.\\Data\\CookSiteDb.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.ToTable("Comment");
        });

        modelBuilder.Entity<CookType>(entity =>
        {
            entity.ToTable("CookType");
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.ToTable("Ingredient");

            entity.HasOne(d => d.AmountUnit).WithMany(p => p.Ingredients)
                .HasForeignKey(d => d.AmountUnitId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Recipe).WithMany(p => p.Ingredients)
                .HasForeignKey(d => d.RecipeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<MediaType>(entity =>
        {
            entity.ToTable("MediaType");
        });

        modelBuilder.Entity<Medium>(entity =>
        {
            entity.HasOne(d => d.MediaType).WithMany(p => p.Media)
                .HasForeignKey(d => d.MediaTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Recipe).WithMany(p => p.Media)
                .HasForeignKey(d => d.RecipeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.ToTable("Recipe");

            entity.HasOne(d => d.CookType).WithMany(p => p.Recipes)
                .HasForeignKey(d => d.CookTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity.ToTable("Setting");

            entity.HasIndex(e => e.Key, "IX_Setting_Key").IsUnique();
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.ToTable("Unit");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
