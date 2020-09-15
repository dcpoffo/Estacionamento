using System;

namespace backend.models
{
     public class Estacionamento
     {
          public int Id { get; set; }
          public DateTime Entrada { get; set; }
          public DateTime Saida { get; set; }
          public double ValorTotal { get; set; }
          public int TabelaPrecoId { get; set; }
          public int VeiculoId { get; set; }
          public TabelaPreco TabelaPreco { get; set; }
          public Veiculo Veiculo { get; set; }

          public Estacionamento() { }

          public Estacionamento(int id, DateTime entrada, DateTime saida, double valorTotal, int tabelaPrecoId, int veiculoId)
          {
               this.Id = id;
               this.Entrada = entrada;
               this.Saida = saida;
               this.ValorTotal = valorTotal;
               this.TabelaPrecoId = tabelaPrecoId;
               this.VeiculoId = veiculoId;
          }
     }
}