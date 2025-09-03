using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranjaken.Application.Dtos.PlayerDto
{
    public class PlayerWithTeamDto
    {
        public Guid? Id { get; set; }
        public string? Pseudo { get; set; }
        public int? Size { get; set; }
        public int? Age { get; set; }
        public string? Position { get; set; }
    }
}
