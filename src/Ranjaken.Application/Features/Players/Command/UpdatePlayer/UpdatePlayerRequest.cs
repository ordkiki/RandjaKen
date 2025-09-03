using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranjaken.Application.Features.Users.Command.UpdatePlayer
{
    public record UpdatePlayerRequest(string? LastName, string? FirstName, int? Size, int? Age, string? Position, string? Experience, string? Avatar); 
}