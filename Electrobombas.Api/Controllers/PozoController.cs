using Electrobombas.Api.Exceptions;
using Electrobombas.Application.Cores.Dtos;
using Electrobombas.Application.Dtos.Pozos;
using Electrobombas.Application.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Electrobombas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PozoController : ControllerBase
    {
        private readonly IPozoService _pozoService;

        public PozoController(IPozoService pozoService)
        {
            _pozoService = pozoService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<PozoDto>))]
        public async Task<Ok<IReadOnlyList<PozoDto>>> Get()
        {
            var response = await _pozoService.FindAllAsync();
            return TypedResults.Ok(response);
        }

        // GET: api/values/2
        [HttpGet("{id:int}", Name = "GetPozoById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PozoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<PozoDto>>> Get(int id)
        {
            var response = await _pozoService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PozoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<PozoDto>>> Post([FromBody] PozoSaveDto saveDto)
        {
            var response = await _pozoService.CreateAsync(saveDto);
            return TypedResults.CreatedAtRoute(response, "GetPozoById", new { id = response.Id });
        }

        // PUT api/values/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PozoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<PozoDto>>> Put(int id, [FromBody] PozoSaveDto saveDto)
        {
            var response = await _pozoService.EditAsync(id, saveDto);
            return TypedResults.Ok(response);
        }

        // DELETE api/values/5
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PozoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<PozoDto>>> Delete(int id)
        {
            var response = await _pozoService.DisabledAsync(id);
            return TypedResults.Ok(response);
        }

        [HttpGet("paginated-search")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PageResponse<PozoDto>))]
        public async Task<Ok<PageResponse<PozoDto>>> PaginatedSearch([FromQuery] PageRequest<PozoFilterDto> request)
        {
            var response = await _pozoService.FindAllPaginatedAsync(request);
            return TypedResults.Ok(response);
        }
    }
}
