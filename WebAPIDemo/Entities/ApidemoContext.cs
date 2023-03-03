using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAPIDemo.Entities;

public partial class ApidemoContext : DbContext
{
    public ApidemoContext()
    {
    }

    public ApidemoContext(DbContextOptions<ApidemoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Accounts> Accounts  { get; set; }
    public virtual DbSet<Student> Student { get; set; }
    public virtual DbSet<Course> Course { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user");

            entity.Property(e => e.EnrollmentDate).HasColumnType("datetime");
            entity.Property(e => e.Firstname).HasMaxLength(45);
            entity.Property(e => e.Lastname).HasMaxLength(45);
            entity.Property(e => e.Password).HasMaxLength(45);
            entity.Property(e => e.Userame).HasMaxLength(45);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
