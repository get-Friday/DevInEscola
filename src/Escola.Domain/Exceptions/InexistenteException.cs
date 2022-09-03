using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.Exceptions
{
    public class InexistenteException : Exception
    {
        public InexistenteException(string message) : base(message)
        {
        }
    }
}
