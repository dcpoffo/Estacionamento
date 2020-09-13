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

          public async Task<Preco[]> GetAllPrecosAsync()
          {
               IQueryable<Preco> query = _context.Preco;
               query = query.AsNoTracking().OrderBy(a => a.Id);
               return await query.ToArrayAsync();
          }

          public async Task<Preco> GetPrecoAsyncById(int precoId)
          {
               IQueryable<Preco> query = _context.Preco;
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
     }
}