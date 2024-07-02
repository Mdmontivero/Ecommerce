﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class SesionDto
    {
        public int IdUsuario { get; set; }
        
        public string? NombreCompleto { get; set; }
        
        public string? Correo { get; set; }
       
        public string? Rol { get; set; }

    }
}
