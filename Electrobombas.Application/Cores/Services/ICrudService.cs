using System;
using System.Collections.Generic;
using System.Text;

namespace Electrobombas.Application.Cores.Services
{
    public interface ICrudService<TDto, TDtoSave, ID> :
        IQueryService<TDto, ID>,
        ISaveService<TDto, TDtoSave, ID>,
        IDisableService<TDto, ID>
    {
    }
}
