using Electrobombas.Domain.Models;
using Electrobombas.Domain.Repositories;
using Electrobombas.Infraestructure.Cores.Context;
using Electrobombas.Infraestructure.Cores.Persistences;
using System;
using System.Collections.Generic;
using System.Text;

namespace Electrobombas.Infraestructure.Persistences
{
    public class MedicionMantenimientoRepository : CrudRepository<MedicionMantenimiento, int>, IMedicionMantenimientoRepository
    {
        public MedicionMantenimientoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
