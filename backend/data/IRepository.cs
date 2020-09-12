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
          Task<Preco[]> GetAllPrecosAsync();
          Task<Preco> GetPrecoAsyncById(int precoId);

          Task<Veiculo[]> GetAllVeiculosAsync();
          Task<Veiculo> GetVeiculoAsyncById(int veiculoId);
          Task<Veiculo> GetVeiculoAsyncByPlaca(string placa);
     }
}