using backend.models;

namespace backend.services
{
     public class VerificaSeNovaVigenciaJaExisteServico
     {
          public bool VerificaSeNovaVigenciaJaExiste(TabelaPreco tabelaPreco, TabelaPreco[] listaTodosPrecos)
          {
               var dataInicial = tabelaPreco.VigenciaInicial.Date;
               var dataFinal = tabelaPreco.VigenciaFinal.Date;

               foreach (var item in listaTodosPrecos)
               {
                    if
                        ((dataInicial >= item.VigenciaInicial.Date && (dataFinal <= item.VigenciaFinal.Date)) ||
                        ((dataFinal >= item.VigenciaInicial.Date && (dataFinal <= item.VigenciaFinal.Date))) ||
                        (dataInicial == item.VigenciaFinal.Date) || (dataFinal <= item.VigenciaInicial.Date))
                    {
                         return true;
                    }

               }
               return false;
          }
     }
}