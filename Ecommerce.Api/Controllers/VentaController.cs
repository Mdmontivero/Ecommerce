using Ecommerce.DTO;
using Ecommerce.Model.Models;
using Ecommerce.Service;
using Ecommerce.Service.implementacion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private IVentaServicio _ventaServicio;

        public VentaController(IVentaServicio ventaServicio)
        {
            _ventaServicio = ventaServicio;
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] VentaDto model)
        {
            var response = new ResponseDto<VentaDto>();

            try
            {

                response.EsCorrecto = true;
                response.Resultado = await _ventaServicio.RegistarVenta(model);


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
