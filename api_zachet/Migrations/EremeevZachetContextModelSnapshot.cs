﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api_zachet.Models;

#nullable disable

namespace api_zachet.Migrations
{
    [DbContext(typeof(EremeevZachetContext))]
    partial class EremeevZachetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("api_zachet.Models.Lesson", b =>
                {
                    b.Property<int>("LessonId")
                        .HasColumnType("int")
                        .HasColumnName("lessonID");

                    b.Property<string>("ClassroomNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("classroomNumber");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date")
                        .HasColumnName("date");

                    b.Property<int>("TariffId")
                        .HasColumnType("int")
                        .HasColumnName("tariffID");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int")
                        .HasColumnName("teacherID");

                    b.HasKey("LessonId");

                    b.HasIndex("TariffId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("api_zachet.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int")
                        .HasColumnName("personID");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nchar(20)")
                        .HasColumnName("name")
                        .IsFixedLength();

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nchar(12)")
                        .HasColumnName("phoneNumber")
                        .IsFixedLength();

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nchar(30)")
                        .HasColumnName("surname")
                        .IsFixedLength();

                    b.HasKey("PersonId");

                    b.HasIndex(new[] { "PhoneNumber" }, "IX_Persons")
                        .IsUnique();

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("api_zachet.Models.Sign", b =>
                {
                    b.Property<int>("SignId")
                        .HasColumnType("int")
                        .HasColumnName("signID");

                    b.Property<int>("PersonId")
                        .HasColumnType("int")
                        .HasColumnName("personID");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nchar(12)")
                        .HasColumnName("phoneNumber")
                        .IsFixedLength();

                    b.HasKey("SignId");

                    b.HasIndex("PersonId");

                    b.HasIndex("PhoneNumber");

                    b.ToTable("Signs");
                });

            modelBuilder.Entity("api_zachet.Models.Tariff", b =>
                {
                    b.Property<int>("TariffId")
                        .HasColumnType("int")
                        .HasColumnName("tariffID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("name")
                        .IsFixedLength();

                    b.Property<decimal>("Price")
                        .HasColumnType("money")
                        .HasColumnName("price");

                    b.HasKey("TariffId");

                    b.ToTable("Tariffs");
                });

            modelBuilder.Entity("api_zachet.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .HasColumnType("int")
                        .HasColumnName("teacherID");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nchar(20)")
                        .HasColumnName("name")
                        .IsFixedLength();

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nchar(12)")
                        .HasColumnName("phoneNumber")
                        .IsFixedLength();

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nchar(30)")
                        .HasColumnName("surname")
                        .IsFixedLength();

                    b.HasKey("TeacherId");

                    SqlServerKeyBuilderExtensions.HasFillFactor(b.HasKey("TeacherId"), 1);

                    b.ToTable("Teacher", (string)null);
                });

            modelBuilder.Entity("api_zachet.Models.Lesson", b =>
                {
                    b.HasOne("api_zachet.Models.Tariff", "Tariff")
                        .WithMany("Lessons")
                        .HasForeignKey("TariffId")
                        .IsRequired()
                        .HasConstraintName("FK_Lessons_Tariffs");

                    b.HasOne("api_zachet.Models.Teacher", "Teacher")
                        .WithMany("Lessons")
                        .HasForeignKey("TeacherId")
                        .IsRequired()
                        .HasConstraintName("FK_Lessons_Teacher");

                    b.Navigation("Tariff");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("api_zachet.Models.Sign", b =>
                {
                    b.HasOne("api_zachet.Models.Person", "Person")
                        .WithMany("SignPeople")
                        .HasForeignKey("PersonId")
                        .IsRequired()
                        .HasConstraintName("FK_Signs_Persons");

                    b.HasOne("api_zachet.Models.Person", "PhoneNumberNavigation")
                        .WithMany("SignPhoneNumberNavigations")
                        .HasForeignKey("PhoneNumber")
                        .HasPrincipalKey("PhoneNumber")
                        .IsRequired()
                        .HasConstraintName("FK_Signs_Persons1");

                    b.Navigation("Person");

                    b.Navigation("PhoneNumberNavigation");
                });

            modelBuilder.Entity("api_zachet.Models.Person", b =>
                {
                    b.Navigation("SignPeople");

                    b.Navigation("SignPhoneNumberNavigations");
                });

            modelBuilder.Entity("api_zachet.Models.Tariff", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("api_zachet.Models.Teacher", b =>
                {
                    b.Navigation("Lessons");
                });
#pragma warning restore 612, 618
        }
    }
}