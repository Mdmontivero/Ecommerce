using Ecommerce.DTO;
using Ecommerce.Service;
using Ecommerce.Service.implementacion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }



        [HttpGet("Lista/{buscar:alpha?}")]
        public async Task<IActionResult> Lista( string buscar = "NA")
        {
            var response = new ResponseDto<List<ProductoDto>>();

            try
            {
                if (buscar == "NA") buscar = "";


                response.EsCorrecto = true;
                response.Resultado = await _productoService.Lista( buscar);


            }
            catch (Exception ex)
            {

                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }


        [HttpGet("Consulta/{id:int}")]
        public async Task<IActionResult> Consulta(int Id)
        {
            var response = new ResponseDto<ProductoDto>();

            try
            {

                response.EsCorrecto = true;
                response.Resultado = await _productoService.Consulta(Id);


            }
            catch (Exception ex)
            {

                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }


        [HttpPost("Create")]

        public async Task<IActionResult> Create([FromBody] ProductoDto model)
        {
            var response = new ResponseDto<ProductoDto>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _productoService.Create(model);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }


        [HttpPut("Edit")]

        public async Task<IActionResult> Edit([FromBody] ProductoDto model)
        {
            var response = new ResponseDto<bool>();

            try
            {

                response.EsCorrecto = true;
                response.Resultado = await _productoService.Edit(model);


            }
            catch (Exception ex)
            {

                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpDelete("Delete/{id :int}")]

        public async Task<IActionResult> Delete([FromBody] int Id)
        {
            var response = new ResponseDto<bool>();

            try
            {

                response.EsCorrecto = true;
                response.Resultado = await _productoService.Delete(Id);


            }
            catch (Exception ex)
            {

                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }


        [HttpGet("Catalogo/{categoria:alpha}/{buscar:alpha?}")]

        public async Task<IActionResult> Catalogo(string categoria, string buscar = "NA")
        {
            var response = new ResponseDto<List<ProductoDto>>();

            try
            {
                if (categoria.ToLower()== "todos") categoria = "";
                if (buscar == "NA") buscar = "";


                response.EsCorrecto = true;
                response.Resultado = await _productoService.Catalogo(categoria, buscar);


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
