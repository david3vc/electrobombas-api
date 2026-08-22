using Electrobombas.Api.Exceptions;
using Electrobombas.Application.Cores.Dtos;
using Electrobombas.Application.Dtos.Mantenimientos;
using Electrobombas.Application.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Electrobombas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MantenimientoController : ControllerBase
    {
        private readonly IMantenimientoService _mantenimientoService;

        public MantenimientoController(IMantenimientoService mantenimientoService)
        {
            _mantenimientoService = mantenimientoService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<MantenimientoDto>))]
        public async Task<Ok<IReadOnlyList<MantenimientoDto>>> Get()
        {
            var response = await _mantenimientoService.FindAllAsync();
            return TypedResults.Ok(response);
        }

        // GET: api/values/2
        [HttpGet("{id:int}", Name = "GetMantenimientoById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MantenimientoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<MantenimientoDto>>> Get(int id)
        {
            var response = await _mantenimientoService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MantenimientoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<MantenimientoDto>>> Post([FromBody] MantenimientoSaveDto saveDto)
        {
            var response = await _mantenimientoService.CreateAsync(saveDto);
            return TypedResults.CreatedAtRoute(response, "GetMantenimientoById", new { id = response.Id });
        }

        // PUT api/values/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MantenimientoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<MantenimientoDto>>> Put(int id, [FromBody] MantenimientoSaveDto saveDto)
        {
            var response = await _mantenimientoService.EditAsync(id, saveDto);
            return TypedResults.Ok(response);
        }

        // DELETE api/values/5
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MantenimientoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<MantenimientoDto>>> Delete(int id)
        {
            var response = await _mantenimientoService.DisabledAsync(id);
            return TypedResults.Ok(response);
        }

        [HttpGet("paginated-search")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PageResponse<MantenimientoDto>))]
        public async Task<Ok<PageResponse<MantenimientoDto>>> PaginatedSearch([FromQuery] PageRequest<MantenimientoFilterDto> request)
        {
            var response = await _mantenimientoService.FindAllPaginatedAsync(request);
            return TypedResults.Ok(response);
        }
    }
}
