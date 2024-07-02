using AutoMapper;
using Ecommerce.DTO;
using Ecommerce.Model.Models;
using Ecommerce.Repositorio.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.implementacion
{
    public class UsuarioService: IUsuarioService
    {
        private IGenericRepositorio<Usuario> _modeloRepositorio;
        private  IMapper _mapper;

        public UsuarioService(IGenericRepositorio<Usuario> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;
        }

        public async Task<SesionDto> Autorizacion(LoginDto model)
        {
            try
            {
                

                var consulta = _modeloRepositorio.Consulta(p => p.Correo == model.Correo && p.Clave == model.Clave);
                var fromDbModel = await consulta.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    return _mapper.Map<SesionDto>(fromDbModel); 
                }
                throw new TaskCanceledException("No se encontro coincidencias");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<UsuarioDto> Create(UsuarioDto model)
        {
            try
            {
                var dbModel = _mapper.Map<Usuario>(model);
                var respModelo = await _modeloRepositorio.Create(dbModel);
                if (respModelo != null)
                {
                    return _mapper.Map<UsuarioDto>(respModelo);
                }
                throw new TaskCanceledException("NO se puede crear");

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<bool> Edit(UsuarioDto model)
        {
            try
            {
                var consulta = _modeloRepositorio.Consulta(p => p.IdUsuario == model.IdUsuario);
                var fromDbModel = await consulta.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    fromDbModel.NombreCompleto = model.NombreCompleto;
                    fromDbModel.Correo = model.Correo;
                    fromDbModel.Clave = model.Clave;

                    var respuesta = await _modeloRepositorio.Edit(fromDbModel);

                    if (!respuesta)
                    {
                        throw new TaskCanceledException("NO se puede Editar");

                    }
                    else
                    {
                        return respuesta;
                    }

                }
                else
                {
                    throw new TaskCanceledException("NO se encontaron resultados");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var consulta = _modeloRepositorio.Consulta(p => p.IdUsuario == id);
                var fromDbModel = await consulta.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    var respuesta = await _modeloRepositorio.Delete(fromDbModel);

                    if (!respuesta)
                    {
                        throw new TaskCanceledException("No se puedo eliminar");

                    }
                    else
                    {
                        return respuesta;
                    }

                }
                else 
                { 
                    throw new TaskCanceledException("No se encontro resultado");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

     

        public async Task<List<UsuarioDto>> Lista(string rol, string buscar)
        {
            try
            {
                var consulta = _modeloRepositorio.Consulta(p => p.Rol == rol && string.Concat(p.NombreCompleto.ToLower(), p.Correo.ToLower()).Contains(buscar.ToLower()));

                List<UsuarioDto> lista = _mapper.Map<List<UsuarioDto>>(await consulta.ToListAsync());
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<UsuarioDto> Consulta(int id)
        {
            try
            {
                var consulta = _modeloRepositorio.Consulta(p => p.IdUsuario == id);
                var fromDbModel= await consulta.FirstOrDefaultAsync();
                if (fromDbModel != null)
                {
                    return _mapper.Map<UsuarioDto>(fromDbModel);
                }
                else
                {
                    throw new TaskCanceledException("No se encontro coincidencia");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

     
    }
}
