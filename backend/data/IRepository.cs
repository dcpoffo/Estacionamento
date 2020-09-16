using System.Threading.Tasks;
using backend.models;

namespace backend.data
{
     public interface IRepository
     {
          void Add<T>(T entity) where T : class;
          void Update<T>(T entity) where T : class;
          void Delete<T>(T entity) where T : class;
          Task<bool> SaveChangesAsync();

          //precos
          Task<TabelaPreco[]> GetAllPrecosAsync();
          Task<TabelaPreco> GetPrecoAsyncById(int precoId);

          Task<Veiculo[]> GetAllVeiculosAsync();
          Task<Veiculo> GetVeiculoAsyncById(int veiculoId);
          Task<Veiculo> GetVeiculoAsyncByPlaca(string placa);

          Task<Estacionamento[]> GetAllEstacionamentosAsync(bool incluirVeiculo, bool incluirPreco);
          Task<Estacionamento> GetEstacionamentoAsyncById(int veiculoId, bool incluirVeiculo, bool incluirPreco);
     }
}