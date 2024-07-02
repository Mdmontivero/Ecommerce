﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class CategoriaDto
    {
        public int IdCategoria { get; set; }
        [Required(ErrorMessage = "Ingrese nombre nombre")]
        public string? Nombre { get; set; }
    }
}
