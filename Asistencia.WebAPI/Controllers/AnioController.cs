using Asistencia.Abstractions.IApplication;
using Asistencia.DTO.Anio;
using Asistencia.DTO.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace Asistencia.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnioController : Controller
    {
        private IAnioApplication _anioApplication;
        public AnioController(IAnioApplication anioApplication)
        {
            this._anioApplication = anioApplication;
        }

        [HttpGet]
        [Route("SpList")]
        public async Task<ActionResult> SpLista()
        {
            try
            {
                var result = await this._anioApplication.SpTraeAnio();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }


        [HttpPost]
        [Route("SpCreate")]
        public async Task<ActionResult> SpInserta(AnioRequest request)
        {
            try
            {

                var result = await this._anioApplication.SpInsertaAnio(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("SpUpdate")]
        public async Task<ActionResult> SpActualiza(AnioRequest request)
        {
            try
            {

                var result = await this._anioApplication.SpActualizaAnio(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [Route("SpDelete")]
        public async Task<ActionResult> SpElimina(string codigo)
        {

            try
            {
                var result = await this._anioApplication.SpEliminaAnio(codigo);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
