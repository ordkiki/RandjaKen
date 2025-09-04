using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranjaken.Domain.Exceptions
{
    public class ExistingEntityException(string message, int code, bool success) : Exception(message)
    {
        public int Code { get; set; } = code;
        public bool Success { get; set; } = success;
    }
    
}
