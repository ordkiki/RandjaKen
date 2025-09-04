using MediatR;
using Ranjaken.Application.Dtos.PlayerDto;
using Ranjaken.Application.Features.Players.Command.CreateManyPlayers;
using Ranjaken.Application.Features.Users.Command.CreatePlayer;

namespace Ranjaken.Application.Features.Users.Command.CreateManyPlayers
{
    public class CreateManyPlayersCommand : IRequest<List<PlayerDto>>
    {
        public List<CreateOnePlayerCommand>? Players { get; set; }
        public Guid? TeamId { get; set; }
    }
}