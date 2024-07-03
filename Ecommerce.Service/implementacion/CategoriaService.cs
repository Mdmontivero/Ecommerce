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
    public class CategoriaService:ICategoriaService
    {
        private IGenericRepositorio<Categoria> _modeloRepositorio;
        private IMapper _mapper;

        public CategoriaService(IGenericRepositorio<Categoria> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;
        }
    

        public async Task<CategoriaDto> Create(CategoriaDto model)
        {
            try
            {
                var dbModel = _mapper.Map<Categoria>(model);
                var respModelo = await _modeloRepositorio.Create(dbModel);
                if (respModelo.IdCategoria != 0)
                {
                    return _mapper.Map<CategoriaDto>(respModelo);
                }
                throw new TaskCanceledException("NO se puede crear");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
     

        public async Task<bool> Edit(CategoriaDto model)
        {
            try
            {
                var consulta = _modeloRepositorio.Consulta(p => p.IdCategoria == model.IdCategoria);
                var fromDbModel = await consulta.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    fromDbModel.Nombre = model.Nombre;

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
                var consulta = _modeloRepositorio.Consulta(p => p.IdCategoria == id);
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
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<CategoriaDto> Consulta(int id)
        {
            try
            {
                var consulta = _modeloRepositorio.Consulta(p => p.IdCategoria == id);
                var fromDbModel = await consulta.FirstOrDefaultAsync();
                if (fromDbModel != null)
                {
                    return _mapper.Map<CategoriaDto>(fromDbModel);
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

        public async Task<List<CategoriaDto>> Lista( string buscar)
        {
            try
            {
                var consulta = _modeloRepositorio.Consulta(p => string.Concat(p.Nombre.ToLower()).Contains(buscar.ToLower()));

                List<CategoriaDto> lista = _mapper.Map<List<CategoriaDto>>(await consulta.ToListAsync());
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
