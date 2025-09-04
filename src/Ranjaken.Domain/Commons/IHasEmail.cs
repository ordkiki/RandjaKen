using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranjaken.Domain.Commons
{
    public interface IHasEmail
    {
        string? EmailAdress { get; set; }
    }
}
