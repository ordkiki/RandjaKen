using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Ranjaken.Domain.Commons;
using Ranjaken.Domain.Entities;
using Ranjaken.Domain.Exceptions;
using Ranjaken.Domain.Interfaces.Repositories;
using RanjaKen.Infrastructure.Contexts;
using System.Linq.Expressions;


namespace RanjaKen.Infrastructure.Persistences.Repositories
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : Entity
    {
        private readonly AppDbContext _db;
        private readonly DbSet<T> _dbSet;
        public GenericRepositoryAsync(AppDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }
        public async Task<T> CreateAsync(T? entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid? id)
        {
            T? result = await _dbSet.FindAsync(id);
            _dbSet.Remove(result);
            return true;
        }
        
        public async Task<T> UpdateAsync(Guid? id, T entity)
        {
            T? existingEntity = await _dbSet.FindAsync(id) ??
            throw new Exception($"Entity with ID  not found");
            
            _db.Entry(existingEntity).CurrentValues.SetValues(entity);
            existingEntity.UpdatedAt = DateTime.UtcNow;
            return existingEntity;
        }
        public async Task SaveChangeAsync()
        {
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception ex) when (ex is DbUpdateConcurrencyException or DbUpdateException)
            {
                throw new ApiException($"Error saving data: {ex.Message}", 400, false);
            }
        }


        public async Task<(IEnumerable<T> Data, long Total, int AllPage)> GetAllAsync(
            Expression<Func<T, bool>>? filterExpression, 
            List<Expression<Func<T, object>>>? includes = null, 
            Func<IQueryable<T>, 
            IOrderedQueryable<T>>? orderBy = null, 
            int? limit = null, 
            int? page = null, 
            int? totalPage = null)
        {
            IQueryable<T> query = _dbSet.Where(filterExpression);

            if (includes != null)
            {
                foreach (Expression<Func<T, object>> include in includes)
                    query = query.Include(include);
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            long total = await query.LongCountAsync();
            int allPage = (limit.HasValue && limit.Value > 0)? (int)Math.Ceiling((double)total / limit.Value): 1;

            if (limit.HasValue && page.HasValue && limit.Value > 0)
            {
                int skip = (page.Value - 1) * limit.Value;
                query = query.Skip(skip).Take(limit.Value);
            }
            return (await query.ToListAsync(), total, allPage);
        }

        public async Task<T?> GetByAsync(Guid? EntityId, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include, Expression<Func<T, T>>? projection = null)
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
                    T? result = await query.FirstOrDefaultAsync(e => e.Id == EntityId);
                    return result;
                }
                else
                {
                    T? result = await _dbSet
                        .Where(e => e.Id == EntityId)
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
        
        public async Task<List<T>> CreateManyAsync(List<T>? entities)
        {
            if (entities == null || !entities.Any())
                throw new ArgumentNullException(nameof(entities));

            await _dbSet.AddRangeAsync(entities);
            return entities;
        }
    }
}