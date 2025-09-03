using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranjaken.Domain.ValuesObject
{
     public record Resource(string Name, string? Url, string? ContentType, string? Extension, int? size);
}
