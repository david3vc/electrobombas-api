using Electrobombas.Domain.Cores.Repositories;
using Electrobombas.Domain.Models;

namespace Electrobombas.Domain.Repositories
{
    public interface IMantenimientoRepository : ICrudRepository<Mantenimiento, int>
    {
    }
}
