using Microsoft.AspNetCore.Mvc;
using SSCafe.UserManagement.Application.DTOs;
using SSCafe.UserManagement.Application.Services;

namespace SSCafe.UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly MenuService _service;

        public MenuController(MenuService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllMenus());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var menu = await _service.GetMenuById(id);

            if (menu == null)
                return NotFound();

            return Ok(menu);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MenuDto dto)
        {
            var menu = await _service.AddMenu(dto);

            return Ok(menu);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] MenuDto dto)
        {
            var menu = await _service.UpdateMenu(id, dto);

            if (menu == null)
                return NotFound();

            return Ok(menu);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteMenu(id);

            if (!result)
                return NotFound();

            return Ok("Menu deleted successfully");
        }
    }
}