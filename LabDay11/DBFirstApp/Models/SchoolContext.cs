using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DBFirstApp.Models;

public partial class SchoolContext : DbContext
{
    public SchoolContext()
    {
    }

    public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Learner> Learners { get; set; }

    public virtual DbSet<Major> Majors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.ToTable("Course");

            entity.Property(e => e.CourseId).ValueGeneratedNever();
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.ToTable("Enrollment");

            entity.HasIndex(e => e.CourseId, "IX_Enrollment_CourseId");

            entity.HasIndex(e => e.LearnerId, "IX_Enrollment_LearnerId");

            entity.HasOne(d => d.Course).WithMany(p => p.Enrollments).HasForeignKey(d => d.CourseId);

            entity.HasOne(d => d.Learner).WithMany(p => p.Enrollments).HasForeignKey(d => d.LearnerId);
        });

        modelBuilder.Entity<Learner>(entity =>
        {
            entity.ToTable("Learner");

            entity.HasIndex(e => e.MajorId, "IX_Learner_MajorId");

            entity.Property(e => e.FirstMidName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);

            entity.HasOne(d => d.Major).WithMany(p => p.Learners).HasForeignKey(d => d.MajorId);
        });

        modelBuilder.Entity<Major>(entity =>
        {
            entity.ToTable("Major");

            entity.Property(e => e.MajorName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
