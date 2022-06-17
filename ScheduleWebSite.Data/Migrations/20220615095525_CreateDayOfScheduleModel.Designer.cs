﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ScheduleWebSite.Data.Contexts;

#nullable disable

namespace ScheduleWebSite.Data.Migrations
{
    [DbContext(typeof(ScheduleContext))]
    [Migration("20220615095525_CreateDayOfScheduleModel")]
    partial class CreateDayOfScheduleModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ScheduleWebSite.Domain.Models.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ScheduleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("ScheduleWebSite.Domain.Models.DayOfSchedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ScheduleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId");

                    b.ToTable("DaysOfSchedules");
                });

            modelBuilder.Entity("ScheduleWebSite.Domain.Models.Lesson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DayOfScheduleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ScheduleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DayOfScheduleId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("ScheduleWebSite.Domain.Models.Schedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("TimeOfCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("ScheduleWebSite.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ScheduleWebSite.Domain.Models.Comment", b =>
                {
                    b.HasOne("ScheduleWebSite.Domain.Models.Schedule", null)
                        .WithMany("Comments")
                        .HasForeignKey("ScheduleId");

                    b.HasOne("ScheduleWebSite.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ScheduleWebSite.Domain.Models.DayOfSchedule", b =>
                {
                    b.HasOne("ScheduleWebSite.Domain.Models.Schedule", null)
                        .WithMany("Days")
                        .HasForeignKey("ScheduleId");
                });

            modelBuilder.Entity("ScheduleWebSite.Domain.Models.Lesson", b =>
                {
                    b.HasOne("ScheduleWebSite.Domain.Models.DayOfSchedule", null)
                        .WithMany("Lessons")
                        .HasForeignKey("DayOfScheduleId");

                    b.HasOne("ScheduleWebSite.Domain.Models.Schedule", "Schedule")
                        .WithMany()
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("ScheduleWebSite.Domain.Models.Schedule", b =>
                {
                    b.HasOne("ScheduleWebSite.Domain.Models.User", "User")
                        .WithMany("Schedules")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ScheduleWebSite.Domain.Models.DayOfSchedule", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("ScheduleWebSite.Domain.Models.Schedule", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Days");
                });

            modelBuilder.Entity("ScheduleWebSite.Domain.Models.User", b =>
                {
                    b.Navigation("Schedules");
                });
#pragma warning restore 612, 618
        }
    }
}
