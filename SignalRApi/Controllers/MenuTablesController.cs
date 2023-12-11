using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;

        public MenuTablesController(IMenuTableService menuTableService)
        {
            _menuTableService = menuTableService;
        }

        [HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {
            return Ok(_menuTableService.TMenuTableCount());
        }

        [HttpGet]
        public IActionResult MenuTableList()
        {
            var values = _menuTableService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
        {
            _menuTableService.TAdd(new MenuTable
            {
                Name = createMenuTableDto.Name,
                Status = false //Müşteri yok anlamında
            });
            return Ok("Masa başarılı bir şekilde eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteMenuTable(int id)
        {
            var value = _menuTableService.TGetByID(id);
            _menuTableService.TDelete(value);
            return Ok("Masa başarılı bir şekilde silindi");
        }

        [HttpPut]
        public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
        {
            _menuTableService.TUpdate(new MenuTable
            {
                MenuTableID = updateMenuTableDto.MenuTableID,
                Name = updateMenuTableDto.Name,
                Status = false
            });
            return Ok("Masa başarılı bir şekilde güncellendi");
        }

        [HttpGet("GetMenuTable")]
        public IActionResult GetMenuTable(int id)
        {
            return Ok(_menuTableService.TGetByID(id));
        }
    }
}