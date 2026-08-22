using System;
using System.Collections.Generic;
using System.Text;

namespace Electrobombas.Application.Cores.Exceptions
{
    public class NotFoundCoreException : Exception
    {
        public NotFoundCoreException(string message) : base(message)
        {
        }
    }
}
