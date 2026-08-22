using Electrobombas.Application.Cores.Services;
using Electrobombas.Application.Dtos.Pozos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Electrobombas.Application.Services
{
    public interface IPozoService : ICrudService<PozoDto, PozoSaveDto, int>, IPageService<PozoDto, PozoFilterDto>
    {
    }
}
