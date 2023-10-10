
using Microsoft.AspNetCore.Mvc;
using Register.Backend.Model;
using Register.Backend.Repository;

namespace Register.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RegistrController : ControllerBase
    {
        private readonly IService _service;

        public RegistrController(IService service)
        {
            _service = service;
        }
        //Bu ruyhatdan utish uchun yozilgan code
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
            return Ok(res);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllData()
        {
            var res = await _service.GetAllUsersAsync();
            if (res == null)
            {
                return NoContent();

            }
            return Ok(res);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _service.GetByIDAsync(id);
            if (res == null)
            {
                return NotFound();

            }
            return Ok(res);
        }
        [HttpDelete]
        public async Task<IActionResult> ISDelete(int id)
        {
            bool res = await _service.RemoveUserAsync(id);
            if (res == false)
            {

                return NotFound();


            }
            return Ok(res);


        }

    }
}
