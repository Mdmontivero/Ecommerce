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
    public class VentaServicio:IVentaServicio
    {
        private IVentaRepositorio _modeloRepositorio;
        private IMapper _mapper;

        public VentaServicio(IVentaRepositorio modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;
        }

        public async Task<VentaDto> RegistarVenta(VentaDto model)
        {
            try
            {
                var dbModel = _mapper.Map<Venta>(model);
                var ventaGenerada = await _modeloRepositorio.Registar(dbModel);
                if (ventaGenerada.IdVenta ==0)
                {
                    throw new TaskCanceledException("NO se pudo registrar");
                }
                return _mapper.Map<VentaDto>(ventaGenerada);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
