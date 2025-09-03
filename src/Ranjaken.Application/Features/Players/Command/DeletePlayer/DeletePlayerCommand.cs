using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranjaken.Application.Features.Users.Command.DeletePlayer
{
    public record DeletePlayerCommand(Guid? Id) : IRequest<bool>;
}
