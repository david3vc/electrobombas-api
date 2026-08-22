using Electrobombas.Application.Dtos.TablaComunes;
using Electrobombas.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Electrobombas.Api.Controllers
{
    [Route("api/[controller]")]
    public class TablaComunController : Controller
    {
        private readonly ITablaComunService _tablaComunService;

        public TablaComunController(ITablaComunService tablaComunService)
        {
            _tablaComunService = tablaComunService;
        }

        [HttpGet("find-all-by-ids")]
        public async Task<IReadOnlyList<TablaComunDto>> FindAllByIds([FromQuery] TablaComunFilterDto filter)
        {
            return await _tablaComunService.FindAllByIdsAsync(filter);
        }
    }
}
