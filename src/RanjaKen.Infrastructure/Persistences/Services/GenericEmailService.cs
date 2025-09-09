
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Ranjaken.Domain.Commons;
using Ranjaken.Domain.Interfaces.Services;
using RanjaKen.Infrastructure.Contexts;
using System.Linq.Expressions;

namespace RanjaKen.Infrastructure.Persistences.Services
{
    public class GenericEmailService<T> : IGenericEmailService<T> where T : Entity, IHasEmail
    {
        private readonly AppDbContext _db;
        private readonly DbSet<T> _dbSet;
        public GenericEmailService(AppDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }
        public async Task<T> GetByEmailAsync(string? email, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include, Expression<Func<T, T>>? projection = null)
        {
            try
            {
                IQueryable<T> query = _dbSet;
                if (include != null)
                {
                    query = include(query);
                }
                if (projection is null)
                {
                    T? result = await query.FirstOrDefaultAsync(e => e.EmailAdress.ToLower() == email.ToLower());
                    return result;
                }
                else
                {
                    T? result = await _db.Set<T>()
                        .Where(e => e.EmailAdress.ToLower() == email.ToLower())
                        .Select(projection)
                        .FirstOrDefaultAsync();
                    return result;
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Erreur Null : {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
                return null;
            }
        }

    }
}
