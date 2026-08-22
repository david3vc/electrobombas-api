using Electrobombas.Domain.Models;
using Electrobombas.Domain.Repositories;
using Electrobombas.Infraestructure.Cores.Context;
using Electrobombas.Infraestructure.Cores.Persistences;

namespace Electrobombas.Infraestructure.Persistences
{
    public class MantenimientoRepository : CrudRepository<Mantenimiento, int>, IMantenimientoRepository
    {
        public MantenimientoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
