using Ecommerce.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service
{
    public interface IProductoService
    {
        Task<List<ProductoDto>> Lista(string buscar);
        Task<List<ProductoDto>> Catalogo(string categoria, string buscar);
        Task<ProductoDto> Consulta(int id);
       
        Task<ProductoDto> Create(ProductoDto model);
        Task<bool> Edit(ProductoDto model);
        Task<bool> Delete(int id);
    }
}
