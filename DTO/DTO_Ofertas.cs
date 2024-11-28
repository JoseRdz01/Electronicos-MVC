using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Ofertas
    {
        [Key]
        public int ID_Oferta { get; set; }

        [Required]
        [Display(Name = "Producto ID")]
        public int Producto_ID { get; set; }

        [Required]
        [Display(Name = "Porcentaje Descuento")]
        public int Porcentage_Desc { get; set; }

        [Required]
        [Display(Name = "Fecha Inicio")]
        public string Fecha_inicio { get; set; }

        [Required]
        [Display(Name = "Fecha Fin")]
        public string Fecha_fin { get; set; }

    }
}
