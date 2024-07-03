using Ecommerce.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service
{
    public interface IVentaServicio
    {
        Task<VentaDto> RegistarVenta(VentaDto model);
    }
}
