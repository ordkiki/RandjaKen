using MediatR;
using Microsoft.AspNetCore.Http;
using Ranjaken.Application.Dtos.PlayerDto;
using Ranjaken.Domain.Enums;
using Ranjaken.Domain.ValuesObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranjaken.Application.Features.Users.Command.CreatePlayer
{
    public class CreatePlayerCommand : IRequest<PlayerDto>
    {
        public Guid? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }
        public string? Pseudo { get; set; }
        public int? Size { get; set; }
        public PlayerPosition? Position { get; set; }
        public IFormFile? Avatar { get; set; }
    }
}