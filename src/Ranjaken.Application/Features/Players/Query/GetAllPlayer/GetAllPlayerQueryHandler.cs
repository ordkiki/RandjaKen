using MediatR;
using Ranjaken.Application.Mappers;
using Ranjaken.Domain.Entities;
using Ranjaken.Domain.Interfaces.Repositories;
using System.Linq.Expressions;

namespace Ranjaken.Application.Features.Users.Query.GetAllPlayer
{
    public class GetAllPlayerQueryHandler(IGenericRepositoryAsync<Player> _repo) : IRequestHandler<GetAllPlayerQuery, GetAllPlayerResponse>
    {
        public async Task<GetAllPlayerResponse> Handle(GetAllPlayerQuery request, CancellationToken cancellationToken)
        {
            List<Expression<Func<Player, object>>> includes = [p => p.Team];
            Expression<Func<Player, bool>> filter = player => true;

            filter = player =>
             (
                     string.IsNullOrEmpty(request.Search) ||
                     player.FirstName.Contains(request.Search) ||
                     player.LastName.Contains(request.Search) ||
                     player.CreatedAt.ToString().Contains(request.Search)
                 )
                 &&
                 (string.IsNullOrEmpty(request.TeamName) ||
                     (player.Team != null && player.Team.Name != null && player.Team.Name.Contains(request.TeamName))
                 )
                 &&
                 (!request.Age.HasValue || (player.Age.HasValue && player.Age.Value <= request.Age.Value)
            );


            (IEnumerable<Player> Data, long Total, int AllPage) = await _repo.GetAllAsync(filter, includes, null, null);
            return new GetAllPlayerResponse()
            {
                Data = [.. Data.ToDtoList()],
                Total = Total,
                TotalPage = AllPage
            };
        }
    }
}