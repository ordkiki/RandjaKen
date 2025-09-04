using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Ranjaken.Application.Mappers;
using Ranjaken.Domain.Entities;
using Ranjaken.Domain.Exceptions;
using Ranjaken.Domain.Interfaces.Repositories;

namespace Ranjaken.Application.Features.Teams.Query.GetBy
{
    public class GetTeamByIdQueryHandler(IGenericRepositoryAsync<Team> _repo) : IRequestHandler<GetTeamByIdQuery, GetTeamByIdResponse>
    {
        public async Task<GetTeamByIdResponse> Handle(GetTeamByIdQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<Team>, IIncludableQueryable<Team, object?>>? include =
                query => query
                    .Include(e => e.Players);
            
            Team? team = await _repo.GetByAsync(request.Id, include ?? null) ??
                throw new ApiException($"We can't found this {request.Id}", 400, false);

            return team.ToDtoWithPlayer();
        }
    }
}