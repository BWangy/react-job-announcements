using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JobAnnouncement.API.Data;

public partial class JobAnnouncementDbContext : DbContext
{
    public JobAnnouncementDbContext()
    {
    }

    public JobAnnouncementDbContext(DbContextOptions<JobAnnouncementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CompetitiveApplication> CompetitiveApplications { get; set; }

    public virtual DbSet<CompetitiveJobAnno> CompetitiveJobAnnos { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<NonCompetitiveApplication> NonCompetitiveApplications { get; set; }

    public virtual DbSet<NonCompetitiveJobAnno> NonCompetitiveJobAnnos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //=> optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=JobAnnounceDemo; Trusted_Connection=True; MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CompetitiveApplication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC071C03C7EE");

            entity.ToTable("CompetitiveApplication");

            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);

            entity.HasOne(d => d.Job).WithMany(p => p.CompetitiveApplications)
                .HasForeignKey(d => d.JobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompetitiveApplication_JobAnno");
        });

        modelBuilder.Entity<CompetitiveJobAnno>(entity =>
        {
            entity.ToTable("CompetitiveJobAnno");

            entity.HasIndex(e => new { e.OpenDate, e.Title }, "AK_CompetitiveJobAnno_1").IsUnique();

            entity.Property(e => e.ApplicationFee).HasColumnType("money");
            entity.Property(e => e.ClosingDate).HasColumnType("datetime");
            entity.Property(e => e.OpenDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Department).WithMany(p => p.CompetitiveJobAnnos)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompetitiveJobAnno_Department");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("Department");

            entity.HasIndex(e => e.Code, "AK_Department_Code").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.Description).HasMaxLength(100);
        });

        modelBuilder.Entity<NonCompetitiveApplication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07FB5A9F15");

            entity.ToTable("NonCompetitiveApplication");

            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.LetterToHr).HasColumnName("LetterToHR");

            entity.HasOne(d => d.Job).WithMany(p => p.NonCompetitiveApplications)
                .HasForeignKey(d => d.JobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NonCompetitiveApplication_JobAnno");
        });

        modelBuilder.Entity<NonCompetitiveJobAnno>(entity =>
        {
            entity.ToTable("NonCompetitiveJobAnno");

            entity.HasIndex(e => new { e.OpenDate, e.Title }, "AK_NonCompetitiveJobAnno_1").IsUnique();

            entity.Property(e => e.ClosingDate).HasColumnType("datetime");
            entity.Property(e => e.OpenDate).HasColumnType("datetime");
            entity.Property(e => e.Restriction).HasMaxLength(200);
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Department).WithMany(p => p.NonCompetitiveJobAnnos)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NonCompetitiveJobAnno_Department");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
