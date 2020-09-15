using System;
using System.Collections.Generic;

namespace backend.models
{
    public class TabelaPreco
    {
        public int Id { get; set; }
          public DateTime VigenciaInicial { get; set; }
          public DateTime VigenciaFinal { get; set; }
          public double ValorHora { get; set; }
          public double ValorHoraAdicional { get; set; }
          public IEnumerable<Estacionamento> Estacionameto { get; set; }

          public TabelaPreco() { }

          public TabelaPreco(int id, DateTime vigenciaInicial, DateTime vigenciaFinal, double valorHora, double valorHoraAdicional)
          {
               this.Id = id;
               this.VigenciaInicial = vigenciaInicial;
               this.VigenciaFinal = vigenciaFinal;
               this.ValorHora = valorHora;
               this.ValorHoraAdicional = valorHoraAdicional;
          }
    }
}