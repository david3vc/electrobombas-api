using Electrobombas.Application.Dtos.TablaComunes;
using Electrobombas.Application.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Electrobombas.Api.Controllers
{
    [Route("api/[controller]")]
    public class TablaComunController : ControllerBase
    {
        private readonly ITablaComunService _tablaComunService;

        public TablaComunController(ITablaComunService tablaComunService)
        {
            _tablaComunService = tablaComunService;
        }

        [HttpGet("find-all-by-ids")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<TablaComunDto>))]
        public async Task<Ok<IReadOnlyList<TablaComunDto>>> FindAllByIds([FromQuery] TablaComunFilterDto filter)
        {
            var response = await _tablaComunService.FindAllByIdsAsync(filter);
            return TypedResults.Ok(response);
        }
    }
}
