using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_BitacoraProductos
    {
        [Key]
        public int ID_Bitacora { get; set; }

        [Required]
        [Display(Name = "Producto ID")]
        public int Producto_ID { get; set; }

        [Required]
        [Display(Name = "Fecha")]
        public string Fecha { get; set; }

        [Required]
        [Display(Name = "Accion")]
        public string Accion { get; set; }
    }
}
