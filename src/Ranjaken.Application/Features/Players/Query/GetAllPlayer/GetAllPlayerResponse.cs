using Ranjaken.Application.Dtos.PlayerDto;
using Ranjaken.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranjaken.Application.Features.Users.Query.GetAllPlayer
{
    public class GetAllPlayerResponse
    {
        public IEnumerable<PlayerDto>? Data { get; set; }
        public long? Total { get; set; }
    }
}
