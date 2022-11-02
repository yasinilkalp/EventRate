using EventRate.Core.Base.Responses;
using Microsoft.AspNetCore.Mvc;

namespace EventRate.Events.Controllers
{
    public class BaseController : ControllerBase
    {
        [NonAction]
        protected IActionResult Success(ApiResponse response)
        {
            return Ok(response);
        }

        [NonAction]
        protected IActionResult Success<T>(ApiResponse<T> response)
        {
            return Ok(response);
        }

        [NonAction]
        protected IActionResult Accepted(ApiResponse response)
        {
            return StatusCode(202, response);
        }

        [NonAction]
        protected IActionResult Accepted<T>(ApiResponse<T> response)
        {
            return StatusCode(202, response);
        }

        [NonAction]
        protected IActionResult BadRequest(ApiResponse response)
        {
            return StatusCode(400, response);
        }

        [NonAction]
        protected IActionResult BadRequest<T>(ApiResponse<T> response)
        {
            return StatusCode(400, response);
        }

        [NonAction]
        protected IActionResult Unauthorized(ApiResponse response)
        {
            return StatusCode(401, response);
        }

        [NonAction]
        protected IActionResult Unauthorized<T>(ApiResponse<T> response)
        {
            return StatusCode(401, response);
        }

        [NonAction]
        protected IActionResult NotFound(ApiResponse response)
        {
            return StatusCode(404, response);
        }

        [NonAction]
        protected IActionResult NotFound<T>(ApiResponse<T> response)
        {
            return StatusCode(404, response);
        }

        [NonAction]
        protected IActionResult Error(ApiResponse response)
        {
            return StatusCode(500, response);
        }

        [NonAction]
        protected IActionResult Error<T>(ApiResponse<T> response)
        {
            return StatusCode(500, response);
        }
    }
}
