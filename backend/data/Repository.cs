using System.Linq;
using System.Threading.Tasks;
using backend.models;
using Microsoft.EntityFrameworkCore;

namespace backend.data
{
     public class Repository : IRepository
     {
          private readonly DataContext _context;

          public Repository(DataContext context)
          {
               this._context = context;
          }

          public void Add<T>(T entity) where T : class
          {
               _context.Add(entity);
          }

          public void Delete<T>(T entity) where T : class
          {
               _context.Remove(entity);
          }

          public void Update<T>(T entity) where T : class
          {
               _context.Update(entity);
          }

          public async Task<bool> SaveChangesAsync()
          {
               return (await _context.SaveChangesAsync()) > 0;
          }

          public async Task<TabelaPreco[]> GetAllPrecosAsync()
          {
               IQueryable<TabelaPreco> query = _context.TabelaPreco;
               query = query.AsNoTracking().OrderBy(a => a.Id);
               return await query.ToArrayAsync();
          }

          public async Task<TabelaPreco> GetPrecoAsyncById(int precoId)
          {
               IQueryable<TabelaPreco> query = _context.TabelaPreco;
               query = query.AsNoTracking().OrderBy(a => a.Id)
                                           .Where(a => a.Id == precoId);

               return await query.FirstOrDefaultAsync();
          }

          public async Task<Veiculo[]> GetAllVeiculosAsync()
          {
               IQueryable<Veiculo> query = _context.Veiculo;
               query = query.AsNoTracking().OrderBy(a => a.Id);
               return await query.ToArrayAsync();
          }

          public async Task<Veiculo> GetVeiculoAsyncById(int veiculoId)
          {
               IQueryable<Veiculo> query = _context.Veiculo;
               query = query.AsNoTracking().OrderBy(a => a.Id)
                                           .Where(a => a.Id == veiculoId);

               return await query.FirstOrDefaultAsync();
          }

          public async Task<Estacionamento[]> GetAllEstacionamentosAsync(bool incluirVeiculo, bool incluirPreco)
          {
               IQueryable<Estacionamento> query = _context.Estacionamento;

               if (incluirVeiculo)
               {
                    query = query.Include(v => v.Veiculo);
               }

               if (incluirPreco)
               {
                    query = query.Include(p => p.TabelaPreco);
               }

               query = query.AsNoTracking().OrderBy(a => a.Id);

               return await query.ToArrayAsync();
          }

          public async Task<Estacionamento> GetEstacionamentoAsyncById(int veiculoId, bool incluirVeiculo, bool incluirPreco)
          {
               IQueryable<Estacionamento> query = _context.Estacionamento;

               if (incluirVeiculo)
               {
                    query = query.Include(v => v.Veiculo);
               }

               if (incluirPreco)
               {
                    query = query.Include(p => p.TabelaPreco);
               }
               
               query = query.AsNoTracking().OrderBy(a => a.Id)
                                           .Where(a => a.Id == veiculoId);

               return await query.FirstOrDefaultAsync();
          }

          public async Task<Veiculo> GetVeiculoAsyncByPlaca(string placa)
          {
               IQueryable<Veiculo> query = _context.Veiculo;
               query = query.AsNoTracking().OrderBy(a => a.Id)
                                           .Where(a => a.Placa == placa);

               return await query.FirstOrDefaultAsync();
          }
     }
}