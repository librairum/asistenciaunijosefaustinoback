
using Asistencia.Abstractions.IApplication;
using Asistencia.DTO.Anio;
using Asistencia.DTO.Perfil;
using Microsoft.AspNetCore.Mvc;

namespace Asistencia.WebAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PerfilController : Controller
    {

        private IPerfilApplication _perfilApplication;

        public PerfilController(IPerfilApplication perfilApplication)
        {
            _perfilApplication = perfilApplication;
        }

        [HttpGet]
        [Route("SpList")]
        public async Task<ActionResult> SpLista()
        {
            try
            {
                var result = await this._perfilApplication.SpTraePerfil();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }


        [HttpPost]
        [Route("SpCreate")]
        public async Task<ActionResult> SpInserta(PerfilRequest request)
        {
            try
            {

                var result = await this._perfilApplication.SpInserta(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("SpUpdate")]
        public async Task<ActionResult> SpActualiza(PerfilRequest request)
        {
            try
            {

                var result = await this._perfilApplication.SpActualiza(request);
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
                var result = await this._perfilApplication.SpElimina(codigo);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
