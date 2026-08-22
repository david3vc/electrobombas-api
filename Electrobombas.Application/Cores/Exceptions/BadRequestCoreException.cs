using System;
using System.Collections.Generic;
using System.Text;

namespace Electrobombas.Application.Cores.Exceptions
{
    public class BadRequestCoreException : Exception
    {
        public BadRequestCoreException(string message) : base(message)
        {
        }
    }
}
