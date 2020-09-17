using backend.models;

namespace backend
{
     public class CalculoValorTotalEstacionamentoServico
     {
          public int quantidadeHoras = 0;
          public int quantidadeMinutos = 0;
          public double meiaHora, valorHora = 0;
          public double CalculoValorTotal(Estacionamento estacionamento)
          {
               quantidadeHoras = estacionamento.Saida.Hour - estacionamento.Entrada.Hour;
               //umaHora = quantidadeHoras - 1;
               quantidadeMinutos = estacionamento.Saida.Minute - estacionamento.Entrada.Minute;
               valorHora = estacionamento.TabelaPreco.ValorHora;
               meiaHora = valorHora / 2;

               if (quantidadeHoras == 0 && quantidadeMinutos < 31)
               {
                    return meiaHora;
               }
               else
               if (quantidadeHoras == 1)
               {
                    return estacionamento.TabelaPreco.ValorHora;
               }
               else
               {
                    if (quantidadeMinutos > 10)
                    {
                         return valorHora + ((quantidadeHoras - 1) * meiaHora) + meiaHora;
                    }
                         return valorHora + ((quantidadeHoras - 1) * meiaHora);                    
               }
          }
     }
}