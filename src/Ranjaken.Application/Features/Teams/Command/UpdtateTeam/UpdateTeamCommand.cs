using MediatR;
using Microsoft.AspNetCore.Http;
using Ranjaken.Application.Dtos;


namespace Ranjaken.Application.Features.Teams.Command.UpdtateTeam
{
    public class UpdateTeamCommand  : IRequest<TeamDto>
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? EmailAdress { get; set; }
        public string? Slogan { get; set; }
        public string? Bio { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Status { get; set; }
        public IFormFile? Logo { get; set; } = null;
    }
}
