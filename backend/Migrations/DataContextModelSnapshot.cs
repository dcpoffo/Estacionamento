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

            modelBuilder.Entity("backend.models.Estacionamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Entrada")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Saida")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("TabelaPrecoId")
                        .HasColumnType("int");

                    b.Property<double>("ValorTotal")
                        .HasColumnType("double");

                    b.Property<int>("VeiculoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TabelaPrecoId");

                    b.HasIndex("VeiculoId");

                    b.ToTable("Estacionamento");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Entrada = new DateTime(2020, 9, 15, 19, 1, 20, 335, DateTimeKind.Local).AddTicks(4560),
                            Saida = new DateTime(2020, 9, 15, 19, 11, 20, 336, DateTimeKind.Local).AddTicks(5497),
                            TabelaPrecoId = 1,
                            ValorTotal = 2.0,
                            VeiculoId = 1
                        },
                        new
                        {
                            Id = 2,
                            Entrada = new DateTime(2020, 9, 15, 19, 1, 20, 336, DateTimeKind.Local).AddTicks(9378),
                            Saida = new DateTime(2020, 9, 15, 19, 36, 20, 336, DateTimeKind.Local).AddTicks(9389),
                            TabelaPrecoId = 2,
                            ValorTotal = 2.0,
                            VeiculoId = 1
                        },
                        new
                        {
                            Id = 3,
                            Entrada = new DateTime(2020, 9, 15, 19, 1, 20, 336, DateTimeKind.Local).AddTicks(9516),
                            Saida = new DateTime(2020, 9, 15, 22, 1, 20, 336, DateTimeKind.Local).AddTicks(9518),
                            TabelaPrecoId = 1,
                            ValorTotal = 2.0,
                            VeiculoId = 2
                        },
                        new
                        {
                            Id = 4,
                            Entrada = new DateTime(2020, 9, 15, 19, 1, 20, 336, DateTimeKind.Local).AddTicks(9549),
                            Saida = new DateTime(2020, 9, 15, 21, 1, 20, 336, DateTimeKind.Local).AddTicks(9550),
                            TabelaPrecoId = 2,
                            ValorTotal = 2.0,
                            VeiculoId = 2
                        });
                });

            modelBuilder.Entity("backend.models.TabelaPreco", b =>
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

                    b.ToTable("TabelaPreco");

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

            modelBuilder.Entity("backend.models.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cor")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Marca")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Modelo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Placa")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Veiculo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cor = "Azul",
                            Marca = "Ford",
                            Modelo = "New Fiesta",
                            Placa = "AAA-1234"
                        },
                        new
                        {
                            Id = 2,
                            Cor = "Prata",
                            Marca = "Chevrolet",
                            Modelo = "Onix",
                            Placa = "BBB-1234"
                        },
                        new
                        {
                            Id = 3,
                            Cor = "Vermelho",
                            Marca = "Fiat",
                            Modelo = "Uno",
                            Placa = "CCC-1234"
                        });
                });

            modelBuilder.Entity("backend.models.Estacionamento", b =>
                {
                    b.HasOne("backend.models.TabelaPreco", "TabelaPreco")
                        .WithMany("Estacionameto")
                        .HasForeignKey("TabelaPrecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.models.Veiculo", "Veiculo")
                        .WithMany("Estacionameto")
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
