using MediatR;

namespace Ranjaken.Application.Features.Players.Query
{
    public class ExportExcelQuery : IRequest<byte[]>
    {
        public string? Search { get; set; }
        public string? TeamName { get; set; }
    }
}