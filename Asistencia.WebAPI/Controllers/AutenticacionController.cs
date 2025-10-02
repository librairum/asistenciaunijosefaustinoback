using Microsoft.AspNetCore.Mvc;
using Asistencia.DTO.Autenticacion;
using Asistencia.Abstractions.IApplication;

namespace Asistencia.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutenticacionController : Controller
    {
        private IAutenticacionApplication _authApplication;
        //public IActionResult Index()
        //{
        //    return View();
        //}
        public AutenticacionController(IAutenticacionApplication authAplicacion)
        {
            this._authApplication = authAplicacion;
        }

        [HttpPost]
        [Route("SpList")]
        public async Task<ActionResult> ObtenerUsuario(AutenticacionRequest request)
        {
            try
            {
                var result = await this._authApplication.SpAccesoUsuario(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       

    }
}
