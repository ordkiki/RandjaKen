using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranjaken.Application.Features.Closes
{
    public class GetDateQueryHandler : IRequestHandler<GetDateQuery, GetDateResponse>
    {
        public Task<GetDateResponse> Handle(GetDateQuery request, CancellationToken cancellationToken)
        {
           
            DateTime startDate = new (2025, 9, 12, 14, 0, 0, DateTimeKind.Utc); // 12/09/2025 00:00:00
            DateTime endDate = new (2025, 09, 30, 0, 0, 0, DateTimeKind.Utc);   // 30/09/2025 00:00:00

            return Task.FromResult(new GetDateResponse
            {
                StartDate = startDate,
                EndDate = endDate
            });
        }
    }
}
