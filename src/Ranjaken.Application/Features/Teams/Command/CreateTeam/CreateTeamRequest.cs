using Microsoft.AspNetCore.Http;
using Ranjaken.Domain.ValuesObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranjaken.Application.Features.Teams.Command.CreateTeam
{
    public record CreateTeamRequest(string? Name, string? Slogan, string? Bio, string? EmailAdress, string? PhoneNumber, IFormFile? Logo);
}
