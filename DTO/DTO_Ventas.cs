using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Ventas
    {
        [Key]
        public int ID_Venta { get; set; }

        [Required]
        [Display(Name = "Producto ID")]
        public int Producto_ID { get; set; }

        [Required]
        [Display(Name = "Ganancia")]
        public int Ganancia { get; set; }

        [Required]
        [Display(Name = "Fecha Venta")]
        public string Fecha_Venta { get; set; }

        [Required]
        [Display(Name = "Sucursal ID")]
        public int Surcursal_ID { get; set; } 

        [Required]
        [Display(Name = "Cantidad")]
        public int Cantidad {  get; set; }
    }
}
