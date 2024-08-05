﻿// <auto-generated />
using System;
using EfCoreEncapsulation.Api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EfCoreEncapsulation.Api.Migrations
{
    [DbContext(typeof(GymContext))]
    partial class GymContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EfCoreEncapsulation.Api.Classes.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ClassId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<string>("Instructor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("ClassId");

                    b.ToTable("Classes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClassName = "Yoga",
                            Instructor = "Alice Johnson"
                        },
                        new
                        {
                            Id = 2,
                            ClassName = "Pilates",
                            Instructor = "Bob Brown"
                        },
                        new
                        {
                            Id = 3,
                            ClassName = "Cycling",
                            Instructor = "Leslie Cabrera"
                        });
                });

            modelBuilder.Entity("EfCoreEncapsulation.Api.Enrollments.Enrollment", b =>
                {
                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.HasKey("MemberId", "ClassId")
                        .HasName("PK_Enrollments");

                    b.HasIndex("ClassId");

                    b.ToTable("Enrollments");

                    b.HasData(
                        new
                        {
                            MemberId = 1,
                            ClassId = 1
                        },
                        new
                        {
                            MemberId = 2,
                            ClassId = 2
                        },
                        new
                        {
                            MemberId = 1,
                            ClassId = 3
                        },
                        new
                        {
                            MemberId = 3,
                            ClassId = 3
                        });
                });

            modelBuilder.Entity("EfCoreEncapsulation.Api.Members.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberId"), 1L, 1);

                    b.Property<DateTime>("MembershipStartDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("StartDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("MemberId")
                        .HasName("PK_Members");

                    b.ToTable("Members", (string)null);

                    b.HasData(
                        new
                        {
                            MemberId = 1,
                            MembershipStartDate = new DateTime(2024, 8, 5, 16, 36, 46, 709, DateTimeKind.Local).AddTicks(5942),
                            Name = "John Doe"
                        },
                        new
                        {
                            MemberId = 2,
                            MembershipStartDate = new DateTime(2024, 8, 5, 16, 36, 46, 709, DateTimeKind.Local).AddTicks(5975),
                            Name = "Jane Smith"
                        },
                        new
                        {
                            MemberId = 3,
                            MembershipStartDate = new DateTime(2024, 8, 5, 16, 36, 46, 709, DateTimeKind.Local).AddTicks(5977),
                            Name = "Paige Patchet"
                        });
                });

            modelBuilder.Entity("EfCoreEncapsulation.Api.Payments.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PaymentId")
                        .HasName("PK_PaymentId");

                    b.HasIndex("MemberId");

                    b.ToTable("Payments", (string)null);
                });

            modelBuilder.Entity("EfCoreEncapsulation.Api.Enrollments.Enrollment", b =>
                {
                    b.HasOne("EfCoreEncapsulation.Api.Classes.Class", "Class")
                        .WithMany("Enrollments")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfCoreEncapsulation.Api.Members.Member", "Member")
                        .WithMany("Enrollments")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("EfCoreEncapsulation.Api.Payments.Payment", b =>
                {
                    b.HasOne("EfCoreEncapsulation.Api.Members.Member", "Member")
                        .WithMany("Payments")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("EfCoreEncapsulation.Api.Classes.Class", b =>
                {
                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("EfCoreEncapsulation.Api.Members.Member", b =>
                {
                    b.Navigation("Enrollments");

                    b.Navigation("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}
