using Microsoft.AspNetCore.Http;
using Ranjaken.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranjaken.Application.Features.Players.Command.CreatePlayer
{
    public record CreatePlayerRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Pseudo { get; set; }
        public string? Idole { get; set; }
        public int? Size { get; set; }
        public PlayerPosition? Position { get; set; }
        public IFormFile? Avatar { get; set; }
        public Guid? TeamId { get; set; }
    }
}
