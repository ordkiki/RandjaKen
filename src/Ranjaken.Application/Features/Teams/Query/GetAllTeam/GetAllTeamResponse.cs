using Ranjaken.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranjaken.Application.Features.Teams.Query.GetAllTeam
{
    public class GetAllTeamResponse
    {
        public IEnumerable<TeamDto>? Data { get; set; }
        public long? Total { get; set; } = 0;
        public int? TotalPage { get; set; } = 0;
    }
}
