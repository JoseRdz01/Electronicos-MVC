using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ProductoSucursal
    {
        [Key]
        public int ID_Existencia_Producto { get; set; }

        [Required]
        [Display(Name = "ID Producto")]
        public int ID_Producto { get; set; }

        [Required]
        [Display(Name = "ID Sucursal")]
        public int ID_Sucursal { get; set; }

        [Required]
        [Display(Name = "Existencia")]
        public int Existencia { get; set; }
    }
}
