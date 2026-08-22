using Electrobombas.Api.Exceptions;
using Electrobombas.Application.Dtos.Mantenimientos;
using Electrobombas.Application.Dtos.MantenimientoTrabajadores;
using Electrobombas.Application.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Electrobombas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MantenimientoTrabajadorController : ControllerBase
    {
        private readonly IMantenimientoTrabajadorService _mantenimientoTrabajadorService;

        public MantenimientoTrabajadorController(IMantenimientoTrabajadorService mantenimientoTrabajadorService)
        {
            _mantenimientoTrabajadorService = mantenimientoTrabajadorService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<MantenimientoTrabajadorDto>))]
        public async Task<Ok<IReadOnlyList<MantenimientoTrabajadorDto>>> Get()
        {
            var response = await _mantenimientoTrabajadorService.FindAllAsync();
            return TypedResults.Ok(response);
        }

        // GET: api/values/2
        [HttpGet("{id:int}", Name = "GetMantenimientoTrabajadorById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MantenimientoTrabajadorDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<MantenimientoTrabajadorDto>>> Get(int id)
        {
            var response = await _mantenimientoTrabajadorService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MantenimientoTrabajadorDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<MantenimientoTrabajadorDto>>> Post([FromBody] MantenimientoTrabajadorSaveDto saveDto)
        {
            var response = await _mantenimientoTrabajadorService.CreateAsync(saveDto);
            return TypedResults.CreatedAtRoute(response, "GetMantenimientoTrabajadorById", new { id = response.Id });
        }

        // PUT api/values/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MantenimientoTrabajadorDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<MantenimientoTrabajadorDto>>> Put(int id, [FromBody] MantenimientoTrabajadorSaveDto saveDto)
        {
            var response = await _mantenimientoTrabajadorService.EditAsync(id, saveDto);
            return TypedResults.Ok(response);
        }

        // DELETE api/values/5
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MantenimientoTrabajadorDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<MantenimientoTrabajadorDto>>> Delete(int id)
        {
            var response = await _mantenimientoTrabajadorService.DisabledAsync(id);
            return TypedResults.Ok(response);
        }
    }
}
