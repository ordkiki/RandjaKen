using Microsoft.AspNetCore.Http;
using Ranjaken.Domain.Enums;
using Ranjaken.Domain.ValuesObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranjaken.Application.Features.Users.Command.CreatePlayer
{
    public record CreatePlayerRequest(string? LastName, string? FirstName, string? Pseudo, int? Size, int? Age, PlayerPosition? Position, string? Experience, IFormFile? Avatar);
}