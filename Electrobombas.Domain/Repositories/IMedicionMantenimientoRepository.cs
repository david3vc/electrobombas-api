using Electrobombas.Domain.Cores.Repositories;
using Electrobombas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Electrobombas.Domain.Repositories
{
    public interface IMedicionMantenimientoRepository : ICrudRepository<MedicionMantenimiento, int>
    {
    }
}
