
using Microsoft.AspNetCore.Mvc;
using SSCafe.UserManagement.Application.DTOs;
using SSCafe.UserManagement.Application.Services;

namespace SSCafe.UserManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly RoleService _service;

        public RoleController(RoleService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAllRoles());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var role = _service.GetRoleById(id);
            if (role == null) return NotFound();

            return Ok(role);
        }

        [HttpPost]
        public IActionResult Add([FromBody] RoleDto dto)
        {
            _service.AddRole(dto);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] RoleDto dto)
        {
            _service.UpdateRole(id, dto);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteRole(id);
            return Ok();
        }
    }
}
