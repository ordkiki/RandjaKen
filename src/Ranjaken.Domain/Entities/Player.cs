using Ranjaken.Domain.Commons;
using Ranjaken.Domain.Enums;
using Ranjaken.Domain.ValuesObject;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ranjaken.Domain.Entities
{
    public class Player : Entity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Pseudo { get; set; }
        public int? Size { get; set; }
        public int? Age { get; set; }
        [DisplayName("text")]
        public PlayerPosition? Position {get; set;}
        public Resource? Avatar { get; set; }
        [ForeignKey(nameof(Team))]
        public Guid? TeamId { get; set; }
        public virtual Team? Team {  get; set; }
    }
}