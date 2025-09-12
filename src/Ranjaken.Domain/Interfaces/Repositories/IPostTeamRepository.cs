using Ranjaken.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranjaken.Domain.Interfaces.Repositories
{
    public interface IPostTeamRepository
    {
        public Task<Team> CreateAsync(Team? entity);
        public Task<Team> UpdateAsync(Guid? id, Team entity);
    }
}