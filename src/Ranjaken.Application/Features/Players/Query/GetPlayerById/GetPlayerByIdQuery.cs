using MediatR;
using Ranjaken.Application.Dtos.PlayerDto;

namespace Ranjaken.Application.Features.Players.Query.GetPlayerById
{
    public record GetPlayerByIdQuery(Guid? Id) : IRequest<PlayerDto>;
    
}
