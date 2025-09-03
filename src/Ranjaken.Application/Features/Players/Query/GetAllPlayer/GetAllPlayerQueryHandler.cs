using MediatR;
using Ranjaken.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ranjaken.Application.Mappers;
using Ranjaken.Domain.Interfaces.Repositories;
namespace Ranjaken.Application.Features.Users.Query.GetAllPlayer
{
    public class GetAllPlayerQueryHandler(IGenericRepositoryAsync<Player> _repo) : IRequestHandler<GetAllPlayerQuery, GetAllPlayerResponse>
    {
        public async Task<GetAllPlayerResponse> Handle(GetAllPlayerQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Player, bool>> filter = player => true;

            filter = player =>

               (
                    string.IsNullOrEmpty(request.Search) ||
                    (
                        player.FirstName.Contains(request.Search) ||
                        player.LastName.Contains(request.Search) ||
                        player.CreatedAt.ToString().Contains(request.Search)
                    )
               )
            ;

            (IEnumerable<Player> Data, long Total, int AllPage) result = await _repo.GetAllAsync(null, null, null, null);
            return new GetAllPlayerResponse()
            {
                Data = result.Data.ToDtoList().ToList(),
                Total = result.Total
            };
        }
    }
}
