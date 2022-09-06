﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OrdersManager.Database;

#nullable disable

namespace OrdersManager.Database.Migrations
{
    [DbContext(typeof(OrdersManagerDbContext))]
    partial class OrdersManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("OrdersManager.Domain.Models.Feedback", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Mark")
                        .HasColumnType("integer");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("OrdersManager.Domain.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uuid");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ClientSurname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ScheduleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId")
                        .IsUnique();

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OrdersManager.Domain.Models.Schedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("MasterId")
                        .HasColumnType("uuid");

                    b.Property<string>("MasterName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MasterSurname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("uuid");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("ServicePrice")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("OrdersManager.Domain.Models.Feedback", b =>
                {
                    b.HasOne("OrdersManager.Domain.Models.Order", "Order")
                        .WithMany("Feedbacks")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("OrdersManager.Domain.Models.Order", b =>
                {
                    b.HasOne("OrdersManager.Domain.Models.Schedule", "Schedule")
                        .WithOne("Order")
                        .HasForeignKey("OrdersManager.Domain.Models.Order", "ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("OrdersManager.Domain.Models.Order", b =>
                {
                    b.Navigation("Feedbacks");
                });

            modelBuilder.Entity("OrdersManager.Domain.Models.Schedule", b =>
                {
                    b.Navigation("Order")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
