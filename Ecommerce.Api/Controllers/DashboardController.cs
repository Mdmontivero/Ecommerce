using Ecommerce.DTO;
using Ecommerce.Service;
using Ecommerce.Service.implementacion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {

        private IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet("Resumen")]
        public  IActionResult Resumen()
        {
            var response = new ResponseDto<DashboardDto>();

            
            try
            {

                response.EsCorrecto = true;
                response.Resultado =  _dashboardService.Resumen();


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
