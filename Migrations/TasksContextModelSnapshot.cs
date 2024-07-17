﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using home;

#nullable disable

namespace home.Migrations
{
    [DbContext(typeof(TasksContext))]
    partial class TasksContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("home.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("17f5abc5-59ef-4564-acfe-ae4cb8c0a6c0"),
                            Name = "Pendientes"
                        },
                        new
                        {
                            Id = new Guid("17f5abc5-59ef-4564-acfe-ae4cb8c0a6c1"),
                            Name = "Completadas"
                        },
                        new
                        {
                            Id = new Guid("17f5abc5-59ef-4564-acfe-ae4cb8c0a6c2"),
                            Name = "En progreso"
                        });
                });

            modelBuilder.Entity("home.Models.Task", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("Effort")
                        .HasMaxLength(10)
                        .HasColumnType("integer");

                    b.Property<int>("Priority")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Task", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("17f5abc5-59ef-4564-acfe-ae4cb8c0a6c3"),
                            CategoryId = new Guid("17f5abc5-59ef-4564-acfe-ae4cb8c0a6c0"),
                            CreateAt = new DateTime(2024, 7, 17, 13, 6, 10, 96, DateTimeKind.Local).AddTicks(9610),
                            Effort = 9,
                            Priority = 2,
                            Title = "MVP proyecto tareas"
                        });
                });

            modelBuilder.Entity("home.Models.Task", b =>
                {
                    b.HasOne("home.Models.Category", "Category")
                        .WithMany("Tasks")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("home.Models.Category", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
