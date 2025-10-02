using Microsoft.AspNetCore.Mvc;
using Asistencia.DTO.Usuario;
using Asistencia.Abstractions.IApplication;
using Asistencia.DTO.Common;

namespace Asistencia.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private IUsuarioApplication _usuarioAplicacion;
        public UsuarioController(IUsuarioApplication usuarioAplicacion)
        {
            this._usuarioAplicacion = usuarioAplicacion;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        [HttpGet]
        [Route("SpList")]
        public async Task<ActionResult> ObtenerLIsta()
        {
            try
            {
                var result = await this._usuarioAplicacion.SpListaUsuaurio();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }


        [HttpPost]
        [Route("SpCreate")]
        public async Task<ActionResult> SpInsertarUsuario(UsuarioCreateRequest request)
        {
            try
            {

                var result = await this._usuarioAplicacion.SpInsertaUsuario(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("SpUpdate")]
        public async Task<ActionResult> SpActualiza(UsuarioCreateRequest request)
        {
            try
            {

                var result = await this._usuarioAplicacion.SpActualizarUsuario(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [Route("SpDelete")]
        public async Task<ActionResult> SpElimina(string codigo, string cuentacod, string empresacod)
        {

            try
            {
                var result = await this._usuarioAplicacion.SpEliminaUsuario(codigo, cuentacod, empresacod);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
