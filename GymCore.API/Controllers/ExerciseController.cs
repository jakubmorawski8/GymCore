using System;
using System.Threading.Tasks;
using GymCore.Application.Exceptions;
using GymCore.Application.Requests.Exercise.Queries.GetExerciseDetails;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExerciseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetExerciseDetailsQueryResponse>> GetExerciseDetails(Guid id)
        {
            var query = new GetExerciseDetailsQuery() { Id = id };
            try
            {
                var response = await _mediator.Send(query);
                return Ok(response);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
    }
}
