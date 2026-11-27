
using Microsoft.AspNetCore.Mvc;
using SSCafe.UserManagement.Application.DTOs;
using SSCafe.UserManagement.Application.Services;

namespace SSCafe.UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAllUsers());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var user = _service.GetUserById(id);
            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Add([FromBody] UserDto dto)
        {
            _service.AddUser(dto);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] UserDto dto)
        {
            _service.UpdateUser(id, dto);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteUser(id);
            return Ok();
        }
    }
}
