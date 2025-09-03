using Ranjaken.Application.Dtos.PlayerDto;
using Ranjaken.Domain.ValuesObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranjaken.Application.Features.Teams.Query.GetBy
{
    public class GetTeamByIdResponse
    {
        public Guid? Id { get; set; }
        public string? Name { get; init; }
        public Resource? Logo { get; set; }
        public string? EmailAdress { get; init; }
        public string? Slogan { get; init; }
        public string? Bio { get; init; }
        public string? PhoneNumber { get; init; }
        public string? Status { get; set; }
        public List<PlayerWithTeamDto>? Players { get; set; }
    }
}
