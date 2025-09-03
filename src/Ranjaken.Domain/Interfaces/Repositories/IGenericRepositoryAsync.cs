using Microsoft.EntityFrameworkCore.Query;
using Ranjaken.Domain.Commons;
using Ranjaken.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ranjaken.Domain.Interfaces.Repositories
{
    public interface IGenericRepositoryAsync<T> where T : Entity
    {
        public Task<Team> GetByEmailAsync(string? email, Func<IQueryable<Team>, IIncludableQueryable<Team, object>>? include, Expression<Func<Team, Team>>? projection = null);
        public Task<T> CreateAsync(T? entity);
        public Task<List<T>> CreateManyAsync(List<T>? entities);
        public Task<bool> DeleteAsync(Guid? id);
        public Task<T> UpdateAsync(Guid? id, T entity);
        public Task<(IEnumerable<T> Data, long Total, int AllPage)> GetAllAsync(
            Expression<Func<T, bool>>? filterExpression,
            List<Expression<Func<T, object>>>? includes = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            int? limit = null,
            int? page = null,
            int? totalPage = null);
        public Task<T> GetByAsync(Guid? Id, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include, Expression<Func<T, T>>? projection = null);
        public Task SaveChangeAsync();
    }
}