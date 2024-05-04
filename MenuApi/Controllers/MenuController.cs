using MenuApi.Domains.Menus;
using MenuApi.Services.Menus;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MenuApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {

        IMenuService _menuService;

        public MenuController(IMenuService menuService) {
            _menuService = menuService;
        }

        // GET api/<MenuController>/5
        [HttpGet("{id}")]
        public Menu Get(int id)
        {
            Menu menu = _menuService.getMenu(id);
            return menu;
            // return _menuService.getMenu(id);
        }

        // POST api/<MenuController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MenuController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MenuController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
