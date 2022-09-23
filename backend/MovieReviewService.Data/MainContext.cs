using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MovieReviewService.Data.Models;

namespace MovieReviewService.Data;

public class MainContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Review> Reviews { get; set; }

    public MainContext(DbContextOptions<MainContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        UserTable(modelBuilder);
        MovieTable(modelBuilder);
        ReviewTable(modelBuilder);
    }

    private static void UserTable(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("User");
        modelBuilder.Entity<User>().HasKey(u => u.Id);
        modelBuilder.Entity<User>().Property(u => u.Address)
            .IsRequired()
            .HasMaxLength(95);
        modelBuilder.Entity<User>().Property(u => u.State)
            .IsRequired()
            .HasMaxLength(15);
        modelBuilder.Entity<User>().Property(u => u.Country)
            .IsRequired()
            .HasMaxLength(50);
        modelBuilder.Entity<User>().Property(u => u.ZipCode)
            .IsRequired()
            .HasMaxLength(12);
        modelBuilder.Entity<User>().Property(u => u.GivenName)
            .IsRequired()
            .HasMaxLength(50);
        modelBuilder.Entity<User>().Property(u => u.FamilyName)
            .IsRequired()
            .HasMaxLength(50);
        modelBuilder.Entity<User>().Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(128);
        modelBuilder.Entity<User>().Property(u => u.FavoriteMovie)
            .IsRequired()
            .HasMaxLength(50);
    }

    private static void MovieTable(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>().ToTable("Movie");
        modelBuilder.Entity<Movie>().HasKey(m => m.Id);
        modelBuilder.Entity<Movie>().Property(m => m.ReleaseDate)
            .IsRequired();
        modelBuilder.Entity<Movie>().Property(m => m.Title)
            .IsRequired()
            .HasMaxLength(25);
        modelBuilder.Entity<Movie>().Property(u => u.MovieTypes)
            .IsRequired();


    }

    private static void ReviewTable(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Review>().ToTable("Review");
        modelBuilder.Entity<Review>().HasKey(r => r.Id);
        modelBuilder.Entity<Review>().Property(r => r.Movie)
            .IsRequired();
        modelBuilder.Entity<Review>().Property(r => r.Rating)
            .IsRequired();
        modelBuilder.Entity<Review>().Property(r => r.Text)
            .IsRequired();
        modelBuilder.Entity<Review>().Property(r => r.Title)
            .IsRequired();
        modelBuilder.Entity<Review>().Property(r => r.User)
            .IsRequired();


    }

}


