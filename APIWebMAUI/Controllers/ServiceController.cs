using APIWebMAUI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using MobileExam.Entities.Services;

namespace APIWebMAUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly DbAb65b9MobilemauiContext _bd;
        public ServiceController(DbAb65b9MobilemauiContext bd) {
            _bd = bd;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var consulta = _bd.TbServices.Where(p => p.ActiveService == "A").Select(p => new ListService
                {
                    idServicio = p.IdService,
                    nombreServicio = p.NameService
                }).ToList();
                return Ok(consulta);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
