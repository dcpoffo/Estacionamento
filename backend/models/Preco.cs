using System;

namespace backend.models
{
     public class Preco
     {
          public int Id { get; set; }
          public DateTime VigenciaInicial { get; set; }
          public DateTime VigenciaFinal { get; set; }
          public double ValorHora { get; set; }

          public Preco() { }

          public Preco(int id, DateTime vigenciaInicial, DateTime vigenciaFinal, double valorHora)
          {
               this.Id = id;
               this.VigenciaInicial = vigenciaInicial;
               this.VigenciaFinal = vigenciaFinal;
               this.ValorHora = valorHora;
          }
     }
}