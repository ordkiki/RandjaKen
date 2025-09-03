namespace Ranjaken.Application.Dtos.PlayerDto
{
    public class PlayerDto
    {
        public Guid? Id { get; set; }
        public string? Pseudo { get; set; }
        public int? Size { get; set; }
        public int? Age { get; set; }
        public string? Position { get; set; }
        public string? TeamName { get; set; }
    }
}