using Ranjaken.Application.Features.Users.Command.CreatePlayer;

namespace Ranjaken.Application.Features.Users.Command.CreateManyPlayers
{
    public record CreateManyPlayersRequest(List<CreatePlayerCommand>? Players);


}