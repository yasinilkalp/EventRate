using EventRate.Events.Application.Commands.Users;
using EventRate.Events.Application.Queries.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EventRate.Events.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IMediator _mediatr; 
        public UserController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }
         
        [HttpPost("LoginByEmail")]
        public async Task<IActionResult> LoginByEmail([FromBody] LoginByEmailQuery query)
        {
            var result = await _mediatr.Send(query);

            if (result == null) NotFound(result);

            return result.Success ? Ok(result) : Accepted(result);
        }

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenQuery query)
        {
            var result = await _mediatr.Send(query);

            if (result == null) NotFound(result);

            return result.Success ? Ok(result) : Accepted(result);
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordQuery query)
        {
            var result = await _mediatr.Send(query);

            if (result == null) NotFound(result); 

            return result.Success ? Ok(result) : Accepted(result);
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePassword command)
        {
            var result = await _mediatr.Send(command);

            if (result == null) NotFound(result);

            return result.Success ? Ok(result) : Accepted(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserUpdate command)
        {
            var result = await _mediatr.Send(command);

            if (result == null) NotFound(result);

            return result.Success ? Ok(result) : Accepted(result);
        } 

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserRegister command)
        {
            var result = await _mediatr.Send(command);

            if (result == null) NotFound(result);

            return result.Success ? Ok(result) : Accepted(result);
        } 
    }
}
