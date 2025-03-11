﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace sql_training.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250311055949_Correction6")]
    partial class Correction6
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Company", b =>
                {
                    b.Property<int>("ComId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ComId"));

                    b.Property<int>("Basic")
                        .HasColumnType("integer");

                    b.Property<string>("ComName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Hrent")
                        .HasColumnType("integer");

                    b.Property<bool>("IsInactive")
                        .HasColumnType("boolean");

                    b.Property<int>("Medical")
                        .HasColumnType("integer");

                    b.HasKey("ComId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Department", b =>
                {
                    b.Property<int>("DeptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DeptId"));

                    b.Property<int>("ComId")
                        .HasColumnType("integer");

                    b.Property<string>("DeptName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("DeptId");

                    b.HasIndex("ComId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Designation", b =>
                {
                    b.Property<int>("DesigId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DesigId"));

                    b.Property<int>("ComId")
                        .HasColumnType("integer");

                    b.Property<string>("DesigName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("DesigId");

                    b.HasIndex("ComId");

                    b.ToTable("Designations");
                });

            modelBuilder.Entity("Employee", b =>
                {
                    b.Property<int>("EmpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EmpId"));

                    b.Property<int>("ComId")
                        .HasColumnType("integer");

                    b.Property<int>("DeptId")
                        .HasColumnType("integer");

                    b.Property<int>("DesigId")
                        .HasColumnType("integer");

                    b.Property<int>("ShiftId")
                        .HasColumnType("integer");

                    b.HasKey("EmpId");

                    b.HasIndex("ComId");

                    b.HasIndex("DeptId");

                    b.HasIndex("DesigId");

                    b.HasIndex("ShiftId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Shift", b =>
                {
                    b.Property<int>("ShiftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ShiftId"));

                    b.Property<int>("ComId")
                        .HasColumnType("integer");

                    b.Property<TimeSpan>("ShiftIn")
                        .HasColumnType("interval");

                    b.Property<bool>("ShiftLate")
                        .HasColumnType("boolean");

                    b.Property<string>("ShiftName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<TimeSpan>("ShiftOut")
                        .HasColumnType("interval");

                    b.HasKey("ShiftId");

                    b.HasIndex("ComId");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("Department", b =>
                {
                    b.HasOne("Company", "Company")
                        .WithMany("Departments")
                        .HasForeignKey("ComId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Designation", b =>
                {
                    b.HasOne("Company", "Company")
                        .WithMany("Designations")
                        .HasForeignKey("ComId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Employee", b =>
                {
                    b.HasOne("Company", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("ComId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DeptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Designation", "Designation")
                        .WithMany("Employees")
                        .HasForeignKey("DesigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shift", "Shift")
                        .WithMany("Employees")
                        .HasForeignKey("ShiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Department");

                    b.Navigation("Designation");

                    b.Navigation("Shift");
                });

            modelBuilder.Entity("Shift", b =>
                {
                    b.HasOne("Company", "Company")
                        .WithMany("Shifts")
                        .HasForeignKey("ComId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Company", b =>
                {
                    b.Navigation("Departments");

                    b.Navigation("Designations");

                    b.Navigation("Employees");

                    b.Navigation("Shifts");
                });

            modelBuilder.Entity("Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Designation", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Shift", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
