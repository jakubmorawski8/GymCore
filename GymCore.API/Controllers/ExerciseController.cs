using System;
using System.Threading.Tasks;
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

        [HttpGet("{id}", Name = "GetExerciseDetails")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetExerciseDetailsQueryResponse>> GetExerciseDetails(Guid id)
        {
            var query = new GetExerciseDetailsQuery() { Id = id };
            var response = await _mediator.Send(query);

            if (response is { ExerciseDetailsVm: null })
            {
                response.Status = StatusCodes.Status404NotFound.ToString();
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
