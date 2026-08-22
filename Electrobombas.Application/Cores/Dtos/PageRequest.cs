using System;
using System.Collections.Generic;
using System.Text;

namespace Electrobombas.Application.Cores.Dtos
{
    public class PageRequest<T>
    {
        public int Page { get; set; }
        public int PerPage { get; set; }
        public T? Filter { get; set; }
    }
}
