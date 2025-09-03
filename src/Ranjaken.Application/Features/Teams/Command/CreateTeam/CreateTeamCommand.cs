using MediatR;
using Microsoft.AspNetCore.Http;
using Ranjaken.Application.Dtos;
using Ranjaken.Domain.ValuesObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranjaken.Application.Features.Teams.Command.CreateTeam
{
    public class CreateTeamCommand : IRequest<TeamDto>
    {
        public Guid Id { get; set; }
        public string? Name { get; init; }
        public Resource? Logo { get; set; }
        public string? EmailAdress { get; init; }
        public string? Slogan { get; init; }
        public string? Bio { get; init; }
        public string? PhoneNumber { get; init; }
        public string? Status { get; set; }
        public IFormFile? Attachement { get; set; }
    }
}
