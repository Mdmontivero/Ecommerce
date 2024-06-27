using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Model.Models;
using Ecommerce.Repositorio.DBcontext;
using Ecommerce.Repositorio.Service;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Ecommerce.Repositorio.Implementacion
{
    public class VentaRepositorio:GenericoRepositorio<Venta>,IVentaRepositorio
    {
        private DbecommerceContext _dbContext;

        public VentaRepositorio(DbecommerceContext dbContext):base(dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<Venta> Registar(Venta venta)
        {
            Venta ventaGenerada = new Venta();

            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach( DetalleVenta dv in venta.DetalleVenta)
                    {
                         Producto producto_encontrado = _dbContext.Productos.Where(p => p.IdProducto == dv.IdProducto).First();

                        producto_encontrado.Cantidad = producto_encontrado.Cantidad-dv.Cantidad;

                        _dbContext.Productos.Update(producto_encontrado);

                        await _dbContext.SaveChangesAsync();

                        await _dbContext.Venta.AddAsync(venta);
                        await _dbContext.SaveChangesAsync();

                        ventaGenerada = venta;
                        transaction.Commit();
                    }

                }
                catch (Exception)
                {

                    transaction.Rollback();
                    throw;
                }

                return ventaGenerada;
            }
        }
    }

}
