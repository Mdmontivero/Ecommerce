using Ecommerce.DTO;
using Ecommerce.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }


        [HttpGet("Lista/{rol:alpha}/{buscar:alpha?}")]
      
        public async Task<IActionResult> Lista(string rol, string buscar = "NA")
        {
            var response = new ResponseDto<List<UsuarioDto>>();

            try
            {
                if(buscar == "NA") buscar = "";


                response.EsCorrecto = true;
                response.Resultado = await _usuarioService.Lista(rol,buscar);
                

            }
            catch (Exception ex)
            {

                response.EsCorrecto = false;    
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet("Consulta/{id:int}")]  
        public async Task<IActionResult> Consulta(int id)
        {
            var response = new ResponseDto<UsuarioDto>();

            try
            {
                    
                    response.EsCorrecto = true;
                    response.Resultado = await _usuarioService.Consulta(id);
                

            }
            catch (Exception ex)
            {

                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost("Create")]

        public async Task<IActionResult> Create([FromBody]UsuarioDto model)
        {
            var response = new ResponseDto<UsuarioDto>();

            try
            {
               
                    response.EsCorrecto = true;
                    response.Resultado = await _usuarioService.Create(model);
                

            }
            catch (Exception ex)
            {

                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost("Autorizacion")]

        public async Task<IActionResult> Autorizacion([FromBody] LoginDto model)
        {
            var response = new ResponseDto<SesionDto>();

            try
            {

                response.EsCorrecto = true;
                response.Resultado = await _usuarioService.Autorizacion(model);


            }
            catch (Exception ex)
            {

                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpPut("Edit")]

        public async Task<IActionResult> Edit([FromBody] UsuarioDto model)
        {
            var response = new ResponseDto<bool>();

            try
            {

                response.EsCorrecto = true;
                response.Resultado = await _usuarioService.Edit(model);


            }
            catch (Exception ex)
            {

                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpDelete("Delete/{id :int}")]

        public async Task<IActionResult> Delete([FromBody] int id)
        {
            var response = new ResponseDto<bool>();

            try
            {

                response.EsCorrecto = true;
                response.Resultado = await _usuarioService.Delete(id);


            }
            catch (Exception ex)
            {

                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

    }
}
