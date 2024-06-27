using Ecommerce.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositorio.Service
{
    public interface IVentaRepositorio:IGenericRepositorio<Venta>
    {
        Task<Venta>Registar(Venta venta);
        
    }
}
