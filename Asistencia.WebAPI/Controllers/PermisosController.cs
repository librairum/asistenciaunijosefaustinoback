using Asistencia.Abstractions.IApplication;
using Asistencia.DTO.Permisos;
using Microsoft.AspNetCore.Mvc;

namespace Asistencia.WebAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PermisosController : Controller
    {
        private IPermisosApplication _permisosApplicaction;

        public PermisosController(IPermisosApplication permisosApplicaction)
        {
            _permisosApplicaction = permisosApplicaction;
        }


        [HttpGet]
        [Route("SpTraeMenuxPerfil")]
        public async Task<ActionResult> SpTraeMenuxPerfil(string codigoPerfil, string codModulo)
        {
            try
            {
                var result = await this._permisosApplicaction.SpTraeMenuxPerfil(codigoPerfil, codModulo);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("SpTodoMenuxPerfil")]
        public async Task<ActionResult> SpTodoMenuxPerfil(string codigoPerfil, string codModulo)
        {
            try
            {
                var result = await this._permisosApplicaction.SpTodoMenuxPerfil(codigoPerfil, codModulo);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("SpInsertaMenuxPerfil")]
        public async Task<ActionResult> SpInsertaMenuxPerfil(PermisosRequest request)
        {
            try
            {

                var result = await this._permisosApplicaction.SpInsertaMenuxPerfil(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
