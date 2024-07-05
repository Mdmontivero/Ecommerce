using Ecommerce.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.DTO;
using AutoMapper;
using Ecommerce.Model.Models;
using Ecommerce.Repositorio.Service;
using Ecommerce.Service.implementacion;


namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet("Lista/{buscar:alpha?}")]


        public async Task<IActionResult> Lista( string buscar = "NA")
        {
            var response = new ResponseDto<List<CategoriaDto>>();

            try
            {
                if (buscar == "NA") buscar = "";


                response.EsCorrecto = true;
                response.Resultado = await _categoriaService.Lista( buscar);


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
            var response = new ResponseDto<CategoriaDto>();

            try
            {

                response.EsCorrecto = true;
                response.Resultado = await _categoriaService.Consulta(Id);


            }
            catch (Exception ex)
            {

                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CategoriaDto model)
        {
            var response = new ResponseDto<CategoriaDto>();

            try
            {

                response.EsCorrecto = true;
                response.Resultado = await _categoriaService.Create(model);


            }
            catch (Exception ex)
            {

                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpPut("Edit")]

        public async Task<IActionResult> Edit([FromBody] CategoriaDto model)
        {
            var response = new ResponseDto<bool>();

            try
            {

                response.EsCorrecto = true;
                response.Resultado = await _categoriaService.Edit(model);


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
                response.Resultado = await _categoriaService.Delete(Id);


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
