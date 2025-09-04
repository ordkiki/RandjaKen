using Ranjaken.Domain.Enums;

namespace Ranjaken.Application.Features.Players.Command.CreateManyPlayers
{
    public record CreatePlayerRequest(string? LastName, string? FirstName, string? Pseudo, int? Size, int? Age, PlayerPosition? Position);
}