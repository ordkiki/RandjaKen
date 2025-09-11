using Ranjaken.Domain.ValuesObject;

namespace Ranjaken.Application.Dtos.PlayerDto
{
    public class PlayerDto
    {
        public Guid? Id { get; set; }
        public string? Pseudo { get; set; }
        public string? Idole { get; set; }
        public int? Size { get; set; }
        public Resource? Avatar { get; set; }
        public int? Age { get; set; }
        public string? Position { get; set; }
        public string? TeamName { get; set; }
        public Guid? TeamId { get; set; }
    }
}