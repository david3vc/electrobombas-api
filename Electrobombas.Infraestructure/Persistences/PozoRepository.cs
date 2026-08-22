using Electrobombas.Domain.Models;
using Electrobombas.Domain.Repositories;
using Electrobombas.Infraestructure.Cores.Context;
using Electrobombas.Infraestructure.Cores.Persistences;

namespace Electrobombas.Infraestructure.Persistences
{
    public class PozoRepository : CrudRepository<Pozo, int>, IPozoRepository
    {
        public PozoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
