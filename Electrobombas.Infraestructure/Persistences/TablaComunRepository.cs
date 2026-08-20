using Electrobombas.Domain.Models;
using Electrobombas.Domain.Repositories;
using Electrobombas.Infraestructure.Cores.Context;
using Electrobombas.Infraestructure.Cores.Persistences;

namespace Electrobombas.Infraestructure.Persistences
{
    public class TablaComunRepository : CrudRepository<TablaComun, int>, ITablaComunRepository
    {
        public TablaComunRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
