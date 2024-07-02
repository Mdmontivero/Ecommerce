using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class TarjetaDto
    {
        [Required(ErrorMessage = "Ingrese nombre Titular ")]
        public string?  Titular { get; set; }
        [Required(ErrorMessage = "Ingrese numero de Tarjeta ")]
        public int? Numero { get; set; }
        [Required(ErrorMessage = "Ingrese fecha de Vencimiento ")]
        public string Vigencia { get; set; }
        [Required(ErrorMessage = " Ingrese CVV")]
        public int? CVV { get; set; }
    }
}
