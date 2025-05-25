using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeriferiaIT.PruebaTecnica.Employees.Application.Login;

namespace PeriferiaIT.PruebaTecnica.Employees.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequestCommand request)
        {
            var result = await mediator.Send(request);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }
    }
}
