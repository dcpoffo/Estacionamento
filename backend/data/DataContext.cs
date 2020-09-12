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

          public DbSet<Preco> Preco { get; set; }
          public DbSet<Veiculo> Veiculo { get; set; }

          protected override void OnModelCreating(ModelBuilder builder)
          {
               builder.Entity<Preco>()
                      .HasData(new List<Preco>(){
                   new Preco(1, DateTime.Parse("2020-01-01"), DateTime.Parse("2020-09-30"), 3.0),
                   new Preco(2, DateTime.Parse("2020-10-01"), DateTime.Parse("2020-12-31"), 5.0),
                      });

               builder.Entity<Veiculo>()
                      .HasData(new List<Veiculo>(){
                   new Veiculo(1, "AAA-1234","Ford","New Fiesta","Azul"),
                   new Veiculo(2, "BBB-1234","Chevrolet","Onix","Prata"),
                   new Veiculo(3, "CCC-1234","Fiat","Uno","Vermelho"),
                  });
          }
     }
}