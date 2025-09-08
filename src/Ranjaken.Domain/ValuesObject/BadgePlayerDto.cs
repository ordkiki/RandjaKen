
using Ranjaken.Domain.Enums;

namespace Ranjaken.Domain.ValuesObject
{
    public class BadgePlayerDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Pseudo { get; set; }
        public int? Size { get; set; }
        public int? Age { get; set; }
        public PlayerPosition? Position { get; set; }
    }
}