using MediatR;
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
            var Player =  await _repo.GetByAsync(request.Id, null, null);
            return Player.ToDto();
        }
    }
}