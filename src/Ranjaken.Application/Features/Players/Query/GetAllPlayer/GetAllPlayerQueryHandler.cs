using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Ranjaken.Application.Mappers;
using Ranjaken.Domain.Entities;
using Ranjaken.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace Ranjaken.Application.Features.Users.Query.GetAllPlayer
{
    public class GetAllPlayerQueryHandler(IGenericRepositoryAsync<Player> _repo) : IRequestHandler<GetAllPlayerQuery, GetAllPlayerResponse>
    {
        public async Task<GetAllPlayerResponse> Handle(GetAllPlayerQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Player, bool>> filter = player => true;

            filter = player => (
                    string.IsNullOrEmpty(request.Search) ||
                    (
                        player.FirstName.Contains(request.Search) ||
                        player.LastName.Contains(request.Search) ||
                        player.CreatedAt.ToString().Contains(request.Search)
                    )
            );
            var includes = new List<Expression<Func<Player, object>>>{p => p.Team};

            (IEnumerable<Player> Data, long Total, int AllPage) = await _repo.GetAllAsync(filter, includes, null, null);
            return new GetAllPlayerResponse()
            {
                Data = [.. Data.ToDtoList()],
                Total = Total
            };
        }
    }
}
