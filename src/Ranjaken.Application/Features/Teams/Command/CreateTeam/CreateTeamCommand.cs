using MediatR;
using Microsoft.AspNetCore.Http;
using Ranjaken.Application.Dtos;

namespace Ranjaken.Application.Features.Teams.Command.CreateTeam
{
    public class CreateTeamCommand : IRequest<TeamDto>
    {
        public string? Name { get; init; }
        public string? EmailAdress { get; init; }
        public string? Slogan { get; init; }
        public string? Bio { get; init; }
        public string? PhoneNumber { get; init; }
        public IFormFile? Logo { get; set; }
    }
}