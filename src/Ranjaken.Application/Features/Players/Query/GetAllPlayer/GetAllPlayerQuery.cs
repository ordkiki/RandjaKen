using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranjaken.Application.Features.Users.Query.GetAllPlayer
{
    public class GetAllPlayerQuery : IRequest<GetAllPlayerResponse>
    {
        public string? Search { get; set; }
        public int Page { get; set; } = 1;
        public int TotalPage { get; set; } = 1;
        public int? Limit { get; set; } = 10;
    }
}
