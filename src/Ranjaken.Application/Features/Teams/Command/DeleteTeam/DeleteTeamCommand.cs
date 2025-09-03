using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranjaken.Application.Features.Teams.Command.DeleteTeam
{
    public record DeleteTeamCommand(Guid? Id) : IRequest<bool>;
}
