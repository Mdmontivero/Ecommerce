using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.DTO;


namespace Ecommerce.Service
{
    internal interface IUsuarioService
    {
        Task<List<UsuarioDto>> Lista(string rol,string buscar);
        Task<UsuarioDto> Consulta(int id);
        Task<SesionDto> Autorizacion(LoginDto model);
        Task<UsuarioDto> Create(UsuarioDto model);
        Task<bool> Edit(UsuarioDto model);
        Task<bool> Delete(int id);
    }
}
