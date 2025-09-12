using MediatR;
using Microsoft.AspNetCore.Http;
using Ranjaken.Application.Dtos.PlayerDto;
using Ranjaken.Domain.Enums;


namespace Ranjaken.Application.Features.Users.Command.CreatePlayer
{
    public class CreatePlayerCommand : IRequest<PlayerDto>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Pseudo { get; set; }
        public string? Idole { get; set; }
        public int? Size { get; set; }
        public PlayerPosition? Position { get; set; }
        public IFormFile? Avatar { get; set; }
        public Guid? TeamId { get; set; }
    }
}