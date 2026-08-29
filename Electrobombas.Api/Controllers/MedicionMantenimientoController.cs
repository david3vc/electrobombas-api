using Electrobombas.Api.Exceptions;
using Electrobombas.Application.Dtos.MedicionMantenimientos;
using Electrobombas.Application.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Electrobombas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicionMantenimientoController : ControllerBase
    {
        private readonly IMedicionMantenimientoService _medicionMantenimientoService;
        public MedicionMantenimientoController(IMedicionMantenimientoService medicionMantenimientoService)
        {
            _medicionMantenimientoService = medicionMantenimientoService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<MedicionMantenimientoDto>))]
        public async Task<Ok<IReadOnlyList<MedicionMantenimientoDto>>> Get()
        {
            var response = await _medicionMantenimientoService.FindAllAsync();
            return TypedResults.Ok(response);
        }

        // GET: api/values/2
        [HttpGet("{id:int}", Name = "GetMedicionMantenimientoById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MedicionMantenimientoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<MedicionMantenimientoDto>>> Get(int id)
        {
            var response = await _medicionMantenimientoService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MedicionMantenimientoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<MedicionMantenimientoDto>>> Post([FromBody] MedicionMantenimientoSaveDto saveDto)
        {
            var response = await _medicionMantenimientoService.CreateAsync(saveDto);
            return TypedResults.CreatedAtRoute(response, "GetMedicionMantenimientoById", new { id = response.Id });
        }

        // PUT api/values/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MedicionMantenimientoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<MedicionMantenimientoDto>>> Put(int id, [FromBody] MedicionMantenimientoSaveDto saveDto)
        {
            var response = await _medicionMantenimientoService.EditAsync(id, saveDto);
            return TypedResults.Ok(response);
        }

        // DELETE api/values/5
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MedicionMantenimientoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<MedicionMantenimientoDto>>> Delete(int id)
        {
            var response = await _medicionMantenimientoService.DisabledAsync(id);
            return TypedResults.Ok(response);
        }
    }
}
