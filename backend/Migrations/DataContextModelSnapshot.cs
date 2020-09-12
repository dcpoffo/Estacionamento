﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.data;

namespace backend.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("backend.models.Preco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("ValorHora")
                        .HasColumnType("double");

                    b.Property<DateTime>("VigenciaFinal")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("VigenciaInicial")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Preco");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ValorHora = 3.0,
                            VigenciaFinal = new DateTime(2020, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VigenciaInicial = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            ValorHora = 5.0,
                            VigenciaFinal = new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VigenciaInicial = new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
