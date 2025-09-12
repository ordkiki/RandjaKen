using Microsoft.EntityFrameworkCore;
using Ranjaken.Domain.Entities;
using Ranjaken.Domain.Exceptions;
using Ranjaken.Domain.Interfaces.Repositories;
using RanjaKen.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RanjaKen.Infrastructure.Persistences.Repositories
{
    internal class PostTeamRepository : IPostTeamRepository
    {
        private readonly AppDbContext _db;
        private readonly DbSet<Team> _dbSet;
        public PostTeamRepository(AppDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<Team>();
        }
        public async Task<Team> CreateAsync(Team? entity)
        {
            
            if (await _dbSet.AnyAsync(t => t.Name.ToLower() == entity!.Name.ToLower()))
                throw new ApiException($"Une équipe avec le nom '{entity!.Name}' existe déjà.", 400, false);

            await _dbSet.AddAsync(entity);
            return entity;
        }

        public Task<Team> UpdateAsync(Guid? id, Team entity)
        {
            throw new NotImplementedException();
        }
    }
}
