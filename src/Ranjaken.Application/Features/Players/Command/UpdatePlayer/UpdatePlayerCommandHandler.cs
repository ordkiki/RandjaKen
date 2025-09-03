using MediatR;
using Ranjaken.Application.Dtos.PlayerDto;
using Ranjaken.Domain.Entities;
using Ranjaken.Domain.Interfaces.Repositories;
using Ranjaken.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranjaken.Application.Features.Users.Command.UpdatePlayer
{
    public class UpdatePlayerCommandHandler(IGenericRepositoryAsync<Player> _repo, IFileService _file) : IRequestHandler<UpdatePlayercommand, PlayerDto>
    {
        public Task<PlayerDto> Handle(UpdatePlayercommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
