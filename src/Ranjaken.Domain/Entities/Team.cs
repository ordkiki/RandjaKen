using Ranjaken.Domain.Commons;
using Ranjaken.Domain.Enums;
using Ranjaken.Domain.ValuesObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranjaken.Domain.Entities
{
    public class Team : Entity
    {
        public string? Name { get; set; }
        public Resource? Logo { get; set; }
        public string? EmailAdress { get; set; }
        public string? Slogan { get; set; }
        public string Bio { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public virtual List<Player>? Players { get; set; }
        [DisplayName("text")]
        public InsriptionStatus? Status { get; set; }
    }
}