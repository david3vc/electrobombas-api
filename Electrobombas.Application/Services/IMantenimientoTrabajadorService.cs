using Electrobombas.Application.Cores.Services;
using Electrobombas.Application.Dtos.MantenimientoTrabajadores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Electrobombas.Application.Services
{
    public interface IMantenimientoTrabajadorService : ICrudService<MantenimientoTrabajadorDto, MantenimientoTrabajadorSaveDto, int>
    {
    }
}
