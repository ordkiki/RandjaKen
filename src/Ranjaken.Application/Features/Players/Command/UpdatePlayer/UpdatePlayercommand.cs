using MediatR;
using Ranjaken.Application.Dtos.PlayerDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranjaken.Application.Features.Users.Command.UpdatePlayer
{
    public class UpdatePlayercommand : IRequest<PlayerDto>
    {
        public Guid? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Matricule { get; set; }
        public string? EmailAdress { get; set; }
        public string? Telephone { get; set; }
    }
}
