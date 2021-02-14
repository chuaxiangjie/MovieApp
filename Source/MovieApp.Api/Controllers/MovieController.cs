using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Application;
using MovieApp.Application.Features.MovieFeatures;
using System.Net;
using System.Threading.Tasks;

namespace MovieApp.Api.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all movies
        /// </summary>
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetMovies([FromQuery] GetMoviesQuery requestModel)
        {
            var responseModel = await _mediator.Send(requestModel);

            if (responseModel.Response == ResponseType.Error)
                return new BadRequestObjectResult(responseModel);

            if (responseModel.Response == ResponseType.Success)
                return Ok(responseModel);

            return StatusCode(500, "Internal Server Error. Somthing went Wrong!");
        }
    }
}
