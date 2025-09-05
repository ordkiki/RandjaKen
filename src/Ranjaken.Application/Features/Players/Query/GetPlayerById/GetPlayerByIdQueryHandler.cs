using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Ranjaken.Application.Dtos.PlayerDto;
using Ranjaken.Application.Mappers;
using Ranjaken.Domain.Entities;
using Ranjaken.Domain.Interfaces.Repositories;

namespace Ranjaken.Application.Features.Players.Query.GetPlayerById
{
    public class GetPlayerByIdQueryHandler(IGenericRepositoryAsync<Player> _repo) : IRequestHandler<GetPlayerByIdQuery, PlayerDto>
    {
        public async Task<PlayerDto> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<Player>, IIncludableQueryable<Player, object>> includes = player => player.Include(player => player.Team);
            Player Player = await _repo.GetByAsync(request.Id, includes, null);
            return Player.ToDto();
        }
    }
}