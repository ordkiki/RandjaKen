using Ranjaken.Domain.Commons;

namespace Ranjaken.Domain.Entities
{
    public class User : Entity, IHasEmail
    {
        public string? EmailAdress { get; set; }
        public string? Password { get; set; }
    }
}