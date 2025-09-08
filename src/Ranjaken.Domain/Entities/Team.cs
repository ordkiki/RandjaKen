using Ranjaken.Domain.Commons;
using Ranjaken.Domain.Enums;
using Ranjaken.Domain.ValuesObject;
using System.ComponentModel;

namespace Ranjaken.Domain.Entities
{
    public class Team : Entity, IHasEmail
    {
        public string? Name { get; set; }
        public Resource? Logo { get; set; }
        public string? EmailAdress { get; set; }
        public string? Slogan { get; set; }
        public string? Bio { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string[]? SocialMedia { get; set; }
        public virtual List<Player>? Players { get; set; }
        [DisplayName("text")]
        public InsriptionStatus? Status { get; set; }
    }
}