using Ecommerce.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service
{
    public interface ICategoriaService
    {
        Task<List<CategoriaDto>> Lista( string buscar);
        Task<CategoriaDto> Consulta(int id);
        Task<CategoriaDto> Create(CategoriaDto model);
        Task<bool> Edit(CategoriaDto model);
        Task<bool> Delete(int id);
    }
}
