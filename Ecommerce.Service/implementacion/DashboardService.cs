using AutoMapper;
using Ecommerce.DTO;
using Ecommerce.Model.Models;
using Ecommerce.Repositorio.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.implementacion
{
    public class DashboardService:IDashboardService
    {
        private IGenericRepositorio<Usuario> _usuarioRepositorio;
        private IGenericRepositorio<Producto> _productoRepositorio;
        private IVentaRepositorio _ventaRepositorio;
        

        public DashboardService(IGenericRepositorio<Usuario> usuarioRepositorio, IGenericRepositorio<Producto> productoRepositorio, IVentaRepositorio ventaRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _productoRepositorio = productoRepositorio;
            _ventaRepositorio = ventaRepositorio;
          
        }

        private string Ingreso()
        {
            var consulta =_ventaRepositorio.Consulta();

            decimal? ingresos = consulta.Sum(x=>x.Total);

            return Convert.ToString(Ingreso);
        }

        private int Venta()
        {
            var consulta = _ventaRepositorio.Consulta();

            int total = consulta.Count();

            return total;
        }

        private int Clientes()
        {
            var consulta = _usuarioRepositorio.Consulta(u => u.Rol.ToLower() == "cliente");

            int total = consulta.Count();

            return total;
        }

        private int Productos()
        {
            var consulta = _productoRepositorio.Consulta();

            int total = consulta.Count();

            return total;
        }
        public DashboardDto Resumen()
        {
            try
            {
                DashboardDto dto = new DashboardDto()
                {
                    TotalIngresos = Ingreso(),
                    TotalVentas = Venta(),
                    TotalClientes = Clientes(),
                    TotalProductos = Productos(),
                };
                return dto;
                 
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
