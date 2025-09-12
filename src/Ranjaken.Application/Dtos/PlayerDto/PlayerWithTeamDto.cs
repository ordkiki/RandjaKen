
namespace Ranjaken.Application.Dtos.PlayerDto
{
    public class PlayerWithTeamDto
    {
        public Guid? Id { get; set; }
        public string? Pseudo { get; set; }
        public string? Idole { get; set; }
        public int? Age { get; set; }
        public int? Size { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Position { get; set; }
    }
}
