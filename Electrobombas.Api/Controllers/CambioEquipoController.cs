using Electrobombas.Api.Exceptions;
using Electrobombas.Application.Dtos.CambioEquipos;
using Electrobombas.Application.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Electrobombas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CambioEquipoController : ControllerBase
    {
        private readonly ICambioEquipoService _cambioEquipoService;
        public CambioEquipoController(ICambioEquipoService cambioEquipoService)
        {
            _cambioEquipoService = cambioEquipoService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<CambioEquipoDto>))]
        public async Task<Ok<IReadOnlyList<CambioEquipoDto>>> Get()
        {
            var response = await _cambioEquipoService.FindAllAsync();
            return TypedResults.Ok(response);
        }

        // GET: api/values/2
        [HttpGet("{id:int}", Name = "GetCambioEquipoById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CambioEquipoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<CambioEquipoDto>>> Get(int id)
        {
            var response = await _cambioEquipoService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CambioEquipoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<CambioEquipoDto>>> Post([FromBody] CambioEquipoSaveDto saveDto)
        {
            var response = await _cambioEquipoService.CreateAsync(saveDto);
            return TypedResults.CreatedAtRoute(response, "GetCambioEquipoById", new { id = response.Id });
        }

        // PUT api/values/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CambioEquipoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<CambioEquipoDto>>> Put(int id, [FromBody] CambioEquipoSaveDto saveDto)
        {
            var response = await _cambioEquipoService.EditAsync(id, saveDto);
            return TypedResults.Ok(response);
        }

        // DELETE api/values/5
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CambioEquipoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<CambioEquipoDto>>> Delete(int id)
        {
            var response = await _cambioEquipoService.DisabledAsync(id);
            return TypedResults.Ok(response);
        }
    }
}
