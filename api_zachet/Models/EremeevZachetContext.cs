using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace api_zachet.Models;

public partial class EremeevZachetContext : DbContext
{
    public EremeevZachetContext()
    {
    }

    public EremeevZachetContext(DbContextOptions<EremeevZachetContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<Person> Persons { get; set; }

    public virtual DbSet<Sign> Signs { get; set; }

    public virtual DbSet<Tariff> Tariffs { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-1VTJNEK;Database=eremeev_zachet; Integrated Security=True; TrustServerCertificate=False; Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.Property(e => e.LessonId)
                .ValueGeneratedNever()
                .HasColumnName("lessonID");
            entity.Property(e => e.ClassroomNumber)
                .HasMaxLength(10)
                .HasColumnName("classroomNumber");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.TariffId).HasColumnName("tariffID");
            entity.Property(e => e.TeacherId).HasColumnName("teacherID");

            entity.HasOne(d => d.Tariff).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.TariffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lessons_Tariffs");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lessons_Teacher");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasIndex(e => e.PhoneNumber, "IX_Persons").IsUnique();

            entity.Property(e => e.PersonId)
                .ValueGeneratedNever()
                .HasColumnName("personID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(12)
                .IsFixedLength()
                .HasColumnName("phoneNumber");
            entity.Property(e => e.Surname)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Sign>(entity =>
        {
            entity.Property(e => e.SignId)
                .ValueGeneratedNever()
                .HasColumnName("signID");
            entity.Property(e => e.PersonId).HasColumnName("personID");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(12)
                .IsFixedLength()
                .HasColumnName("phoneNumber");

            entity.HasOne(d => d.Person).WithMany(p => p.SignPeople)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Signs_Persons");

            entity.HasOne(d => d.PhoneNumberNavigation).WithMany(p => p.SignPhoneNumberNavigations)
                .HasPrincipalKey(p => p.PhoneNumber)
                .HasForeignKey(d => d.PhoneNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Signs_Persons1");
        });

        modelBuilder.Entity<Tariff>(entity =>
        {
            entity.Property(e => e.TariffId)
                .ValueGeneratedNever()
                .HasColumnName("tariffID");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasFillFactor(1);

            entity.ToTable("Teacher");

            entity.Property(e => e.TeacherId)
                .ValueGeneratedNever()
                .HasColumnName("teacherID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(12)
                .IsFixedLength()
                .HasColumnName("phoneNumber");
            entity.Property(e => e.Surname)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("surname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
