using Ranjaken.Domain.Entities;
using Ranjaken.Domain.Enums;
using Ranjaken.Domain.ValuesObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranjaken.Application.Dtos
{
    public class TeamDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; init; }
        public Resource? Logo { get; set; }
        public string? EmailAdress { get; init; }
        public string? Slogan { get; init; }
        public string? Bio { get; init; }
        public string? PhoneNumber { get; init; }
        public string[]? SocialMedia { get; set; }
        public string? Status { get; set; }
    }
}