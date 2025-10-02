using Asistencia.Abstractions.IApplication;
using Asistencia.DTO.Anio;
using Asistencia.DTO.Marcador;
using Microsoft.AspNetCore.Mvc;

namespace Asistencia.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MarcadorController : Controller
    {

        private IMarcadorApplication _marcadorApplication;
        public MarcadorController(IMarcadorApplication marcadorApplication)
        {
            _marcadorApplication = marcadorApplication;
        }



        [HttpGet]
        [Route("SpLista")]
        public async Task<ActionResult> SpLista()
        {
            try
            {
                var result = await this._marcadorApplication.SpTrae();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }



        [HttpPost]
        [Route("SpInserta")]
        public async Task<ActionResult> SpInserta(MarcadorRequest request)
        {

            try
            {

                var result = await this._marcadorApplication.SpInserta(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
          
        }

        [HttpDelete]
        [Route("SpElimina")]
        public async Task<ActionResult> SpElimina(string codigoMarcadorCliente, string codigoMarcadorProveedor)
        {

            try
            {

                var result = await this._marcadorApplication.SpElimina(codigoMarcadorCliente, codigoMarcadorProveedor);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
