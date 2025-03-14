using APIWebMAUI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using MobileExam.Entities.Register;
using MobileExam.Entities.Services;

namespace APIWebMAUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly DbAb65b9MobilemauiContext _bd;
        public RegisterController(DbAb65b9MobilemauiContext bd) 
        {
            _bd = bd;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var consulta = _bd.TbRegisterpets.Where(p=>p.ActiveRegister == "A").Select(p => new ListRegister
                {
                    idRegister = p.IdRegisterpet,
                    petName = p.NamePet,
                    nameService = p.IdServiceNavigation.NameService,
                    dateService = (DateTime)p.DateService
                }).ToList();
                return Ok(consulta);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var objPetrecord = _bd.TbRegisterpets.FirstOrDefault(p => p.IdRegisterpet == id);
                if (objPetrecord == null) return NotFound();
                
                return Ok(new FormRegister
                    {
                    idRegister = objPetrecord.IdRegisterpet,
                    petName = objPetrecord.NamePet,
                    idServicio = (int)objPetrecord.IdService,
                    dateService = (DateTime)objPetrecord.DateService
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]FormRegister oFormRegister)
        {
            try
            {
                if(oFormRegister.idRegister == 0)
                {
                    TbRegisterpet oTbRegisterpet = new TbRegisterpet();
                    oTbRegisterpet.NamePet = oFormRegister.petName;
                    oTbRegisterpet.IdService = oFormRegister.idServicio;
                    oTbRegisterpet.DateService = oFormRegister.dateService;
                    oTbRegisterpet.ActiveRegister = "A";
                    _bd.TbRegisterpets.Add(oTbRegisterpet);
                    _bd.SaveChanges();
                    return Ok("Registro guardado correctamente");
                }
                else
                {
                    var oTbRegisterpet = _bd.TbRegisterpets.Find(oFormRegister.idRegister);
                    if(oTbRegisterpet == null)
                    {
                        return NotFound();
                    }
                    oTbRegisterpet.NamePet = oFormRegister.petName;
                    oTbRegisterpet.IdService = oFormRegister.idServicio;
                    oTbRegisterpet.DateService = oFormRegister.dateService;
                    _bd.SaveChanges();
                    return Ok("Se actualizo registro correctamente");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var objPetrecord = _bd.TbRegisterpets.FirstOrDefault(p => p.IdRegisterpet == id);
                if (objPetrecord == null) return NotFound();
                objPetrecord.ActiveRegister = "I";
                _bd.SaveChanges();
                return Ok("El registro de la mascota se elimino correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
