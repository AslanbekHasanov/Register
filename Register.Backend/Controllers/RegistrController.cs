
using Microsoft.AspNetCore.Mvc;
using Register.Backend.Model;
using Register.Backend.Repository;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace Register.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RegistrController : ControllerBase
    {
        private readonly Service _service;

        public RegistrController(Service service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromForm]User user)
        {
            bool res = await _service.SignUpAsync(user);
            if (res == false)
            {
                return BadRequest();
                
            }
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> LogIn(string email, string password)
        {
            var res = await _service.LogIn(email, password);
            if (res == false)
            {
                return NotFound();

            }
            return Ok();
        }


    }
}
