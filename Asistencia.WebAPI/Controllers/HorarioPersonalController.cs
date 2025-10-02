using Asistencia.Abstractions.IApplication;
using Asistencia.DTO.Horario;
using Asistencia.DTO.HorarioPersonal;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Asistencia.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HorarioPersonalController : Controller
    {
        private IHorarioPersonalApplication _application;
        public HorarioPersonalController(IHorarioPersonalApplication application)
        {
            _application = application;
        }

        [HttpPut]
        [Route("SpActualiza")]
        public async Task<ActionResult> SpActualiza(HorarioPersonalRequest entidad)
        {
            try {
                var result = await this._application.SpActualiza(entidad);
                return Ok(result);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("SpInserta")]
        public async Task<ActionResult> SpInserta(HorarioPersonalRequest entidad)
        {

            try {
                var result = await this._application.SpInserta(entidad);
                return Ok(result);
            }catch(Exception ex) {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("SpTrae")]
        public async Task<ActionResult> SpTrae(string EmpresaCod)
        {
            try {
                var result = await this._application.SpTraeHorarios(EmpresaCod);
                return Ok(result);
            }catch( Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("SpTraeDet")]
        public async Task<ActionResult> SpTraeHorarioDet(string empresaCod,string idpersonal, string dia)
        {
            try {
                var result = await this._application.SpTraeHorarioDet(empresaCod, idpersonal, dia);
                return Ok(result);
            }catch( Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("SpActualizaMasivo")]
        public async Task<ActionResult> SpActualizaHorariosMasivo([FromBody] HorarioMasivoRequest entidad)
        {
            try
            {
                var result = await this._application.SpActualizaHorariosMasivo(entidad);
                return Ok(result);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPut]
        [Route("SpActualizaDinamico")]
        public async Task<ActionResult> SpActualizaDinamico(HorarioPersonalRequest entidad)
        {
            try
            {
                var result = await this._application.SpActualizaHorarioDinamico(entidad);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
