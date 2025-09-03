using Ranjaken.Domain.Commons;
using Ranjaken.Domain.Enums;
using Ranjaken.Domain.ValuesObject;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Ranjaken.Domain.Entities
{
    public class Player : Entity
    {
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? Pseudo { get; init; }
        public int? Size { get; init; }
        public int? Age { get; init; }
        [DisplayName("text")]
        public PlayerPosition? Position {get; init;}
        public Resource? Avatar { get; set; }
        [ForeignKey(nameof(Team))]
        public Guid? TeamId { get; init; }
        public virtual Team? Team {  get; set; }
    }
}