
using Microsoft.AspNetCore.Mvc;
using SSCafe.UserManagement.Application.DTOs;
using SSCafe.UserManagement.Application.Services;

namespace SSCafe.UserManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserRoleController : ControllerBase
    {
        private readonly UserRoleService _service;

        public UserRoleController(UserRoleService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAllUserRoles());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var userRole = _service.GetUserRoleById(id);
            if (userRole == null) return NotFound();

            return Ok(userRole);
        }

        [HttpPost]
        public IActionResult Add([FromBody] UserRoleDto dto)
        {
            _service.AddUserRole(dto);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] UserRoleDto dto)
        {
            _service.UpdateUserRole(id, dto);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteUserRole(id);
            return Ok();
        }
    }
}
