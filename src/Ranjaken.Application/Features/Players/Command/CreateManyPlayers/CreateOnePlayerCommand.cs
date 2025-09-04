using Microsoft.AspNetCore.Http;
using Ranjaken.Domain.Enums;
using Ranjaken.Domain.ValuesObject;

namespace Ranjaken.Application.Features.Players.Command.CreateManyPlayers
{
    public record CreateOnePlayerCommand
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }
        public string? Pseudo { get; set; }
        public Resource? Avatar { get; set; }
        public int? Size { get; set; }
        public PlayerPosition? Position { get; set; }
    }
}