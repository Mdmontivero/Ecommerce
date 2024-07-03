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
    public class ProductoService:IProductoService
    {
        private IGenericRepositorio<Producto> _modeloRepositorio;
        private IMapper _mapper;

        public ProductoService(IGenericRepositorio<Producto> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;
        }

        public async Task<List<ProductoDto>> Catalogo(string categoria, string buscar)
        {
            try
            {
                var consulta = _modeloRepositorio.Consulta(p => p.Nombre.ToLower().Contains(categoria.ToLower()));

                List<ProductoDto> lista = _mapper.Map<List<ProductoDto>>(await consulta.ToListAsync());
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ProductoDto> Consulta(int id)
        {
            try
            {

                var consulta = _modeloRepositorio.Consulta(p => p.IdProducto == id);

                consulta.Include(c => c.IdCategoriaNavigation);

                var fromDbModel = await consulta.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    return _mapper.Map<ProductoDto>(fromDbModel);
                }
                throw new TaskCanceledException("No se encontro coincidencias");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ProductoDto> Create(ProductoDto model)
        {
            try
            {
                var dbModel = _mapper.Map<Producto>(model);
                var respModelo = await _modeloRepositorio.Create(dbModel);
                if (respModelo.IdProducto != 0)
                {
                    return _mapper.Map<ProductoDto>(respModelo);
                }
                throw new TaskCanceledException("NO se puede crear");

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
                var consulta = _modeloRepositorio.Consulta(p => p.IdProducto == id);
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

        public async Task<bool> Edit(ProductoDto model)
        {
            try
            {
                var consulta = _modeloRepositorio.Consulta(p => p.IdProducto == model.IdProducto);
                var fromDbModel = await consulta.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    fromDbModel.Nombre = model.Nombre;
                    fromDbModel.Precio = model.Precio;
                    fromDbModel.PrecioOferta = model.PrecioOferta;
                    fromDbModel.Cantidad = model.Cantidad;
                    fromDbModel.Descripcion = model.Descripcion;
                    fromDbModel.IdCategoria = model.IdCategoria;
                    fromDbModel.Imagen = model.Imagen;
                   

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

        public async Task<List<ProductoDto>> Lista(string buscar)
        {
            try
            {
                var consulta = _modeloRepositorio.Consulta(p => p.Nombre.ToLower().Contains(buscar.ToLower()));

                consulta.Include(c => c.IdCategoriaNavigation);

                List<ProductoDto> lista = _mapper.Map<List<ProductoDto>>(await consulta.ToListAsync());
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
