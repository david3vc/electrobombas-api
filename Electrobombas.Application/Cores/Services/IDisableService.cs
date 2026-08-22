using System;
using System.Collections.Generic;
using System.Text;

namespace Electrobombas.Application.Cores.Services
{
    public interface IDisableService<TDto, ID>
    {
        Task<TDto> DisabledAsync(ID id);
    }
}
