﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Payrol.Data;

namespace Payrol.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210929035233_addDepartmentToDatabase")]
    partial class addDepartmentToDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Payrol.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartmentLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("Payrol.Models.Salary", b =>
                {
                    b.Property<int>("SalaryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("SalaryBasic")
                        .HasColumnType("float");

                    b.Property<double>("SalaryKwsp")
                        .HasColumnType("float");

                    b.Property<double>("SalaryOvertime")
                        .HasColumnType("float");

                    b.Property<double>("SalaryPerformanceAllowance")
                        .HasColumnType("float");

                    b.Property<int>("SalaryStaffId")
                        .HasColumnType("int");

                    b.Property<double>("SalaryTransportAllowance")
                        .HasColumnType("float");

                    b.HasKey("SalaryId");

                    b.HasIndex("SalaryStaffId");

                    b.ToTable("Salary");
                });

            modelBuilder.Entity("Payrol.Models.Staff", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("StaffAge")
                        .HasColumnType("int");

                    b.Property<int>("StaffDepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("StaffName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StaffId");

                    b.HasIndex("StaffDepartmentId");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("Payrol.Models.Salary", b =>
                {
                    b.HasOne("Payrol.Models.Staff", "Staff")
                        .WithMany("Salaries")
                        .HasForeignKey("SalaryStaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("Payrol.Models.Staff", b =>
                {
                    b.HasOne("Payrol.Models.Department", "Department")
                        .WithMany("Staffs")
                        .HasForeignKey("StaffDepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Payrol.Models.Department", b =>
                {
                    b.Navigation("Staffs");
                });

            modelBuilder.Entity("Payrol.Models.Staff", b =>
                {
                    b.Navigation("Salaries");
                });
#pragma warning restore 612, 618
        }
    }
}
