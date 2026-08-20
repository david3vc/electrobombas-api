using Electrobombas.Domain.Models;
using Electrobombas.Domain.Repositories;
using Electrobombas.Infraestructure.Cores.Context;
using Electrobombas.Infraestructure.Cores.Persistences;
using System;
using System.Collections.Generic;
using System.Text;

namespace Electrobombas.Infraestructure.Persistences
{
    public class TablaComunRepository : CrudRepository<TablaComun, int>, ITablaComunRepository
    {
        public TablaComunRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
