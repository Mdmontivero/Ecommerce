using AutoMapper;
using Ecommerce.DTO;
using Ecommerce.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Utilidades
{
    public class AutoMapperProfile : Profile
    {
        protected AutoMapperProfile()
        {
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<Usuario, SesionDto>();
            CreateMap<UsuarioDto,Usuario>();

            CreateMap<Categoria, CategoriaDto>();
            CreateMap<CategoriaDto, Categoria>();

            CreateMap<Producto, ProductoDto>();
            CreateMap<ProductoDto, Producto>().ForMember(destino => destino.IdCategoriaNavigation, opt => opt.Ignore());

            CreateMap<DetalleVenta, DetalleVentaDto>();
            CreateMap<DetalleVentaDto, DetalleVenta>();

            CreateMap<Venta, VentaDto>();
            CreateMap<VentaDto,Venta>();
        }
    }
}
