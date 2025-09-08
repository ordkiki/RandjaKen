using Microsoft.EntityFrameworkCore.Query;
using Ranjaken.Domain.Commons;
using System.Linq.Expressions;

namespace Ranjaken.Domain.Interfaces.Services
{
    public interface IGenericEmailService<T> where T : IHasEmail
    {
        public Task<T> GetByEmailAsync(string? email, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include, Expression<Func<T, T>>? projection = null);
    }
}