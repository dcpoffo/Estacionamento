using System;
using System.Collections.Generic;
using backend.models;
using Microsoft.EntityFrameworkCore;

namespace backend.data
{
     public class DataContext : DbContext
     {
          public DataContext(DbContextOptions<DataContext> options) : base(options)
          { }

          public DbSet<TabelaPreco> TabelaPreco { get; set; }
          public DbSet<Veiculo> Veiculo { get; set; }
          public DbSet<Estacionamento> Estacionamento { get; set; }

          protected override void OnModelCreating(ModelBuilder builder)
          {
               builder.Entity<TabelaPreco>()
                      .HasData(new List<TabelaPreco>(){
                   new TabelaPreco(1, DateTime.Parse("2020-01-01"), DateTime.Parse("2020-09-30"), 3.0, 1.5),
                   new TabelaPreco(2, DateTime.Parse("2020-10-01"), DateTime.Parse("2020-12-31"), 5.0, 2.0),
                      });

               builder.Entity<Veiculo>()
                      .HasData(new List<Veiculo>(){
                   new Veiculo(1, "AAA-1234","Ford","New Fiesta","Azul"),
                   new Veiculo(2, "BBB-1234","Chevrolet","Onix","Prata"),
                   new Veiculo(3, "CCC-1234","Fiat","Uno","Vermelho"),
                  });

               builder.Entity<Estacionamento>()
                   .HasData(new List<Estacionamento>(){
                   new Estacionamento(1,DateTime.Now, DateTime.Now.AddMinutes(10),2.0,1,1),
                   new Estacionamento(2,DateTime.Now, DateTime.Now.AddMinutes(35),2.0,2,1),
                   new Estacionamento(3,DateTime.Now, DateTime.Now.AddHours(3),2.0,1,2),
                   new Estacionamento(4,DateTime.Now, DateTime.Now.AddHours(2),2.0,2,2),
               });
          }
     }
}