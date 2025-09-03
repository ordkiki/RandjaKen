using MediatR;
using Ranjaken.Application.Dtos.PlayerDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranjaken.Application.Features.Players.Query.GetPlayerById
{
    public record GetPlayerByIdQuery(Guid? Id) : IRequest<PlayerDto>;
    
}
