﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ScheduleService.Infrastructure.Data;

#nullable disable

namespace ScheduleService.Infrastructure.Migrations
{
    [DbContext(typeof(ScheduleDbContext))]
    partial class ScheduleDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ScheduleService.Domain.Entities.EmployeeShift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<TimeOnly>("End")
                        .HasColumnType("time without time zone");

                    b.Property<int>("SchoolOperatingDayId")
                        .HasColumnType("integer");

                    b.Property<TimeOnly>("Start")
                        .HasColumnType("time without time zone");

                    b.HasKey("Id");

                    b.HasIndex("SchoolOperatingDayId");

                    b.ToTable("EmployeeShifts", (string)null);
                });

            modelBuilder.Entity("ScheduleService.Domain.Entities.SchoolOperatingDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int>("DayType")
                        .HasColumnType("integer");

                    b.Property<TimeOnly>("End")
                        .HasColumnType("time without time zone");

                    b.Property<TimeOnly>("Start")
                        .HasColumnType("time without time zone");

                    b.HasKey("Id");

                    b.ToTable("SchoolOperatingDays", (string)null);
                });

            modelBuilder.Entity("ScheduleService.Domain.Entities.EmployeeShift", b =>
                {
                    b.HasOne("ScheduleService.Domain.Entities.SchoolOperatingDay", "SchoolOperatingDay")
                        .WithMany()
                        .HasForeignKey("SchoolOperatingDayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SchoolOperatingDay");
                });
#pragma warning restore 612, 618
        }
    }
}
