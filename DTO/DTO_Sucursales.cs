using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Sucursales
    {
        [Key]
        public int ID_Sucursal { get; set; }

        [Required]
        [Display(Name = "Nombre Sucursal")]
        public string Nombre_Sucursal { get; set; }

        [Required]
        [Display(Name = "Calle")]
        public string Calle { get; set; }

        [Required]
        [Display(Name = "Numero")]
        public string Numero { get; set; }

        [Required]
        [Display(Name = "Colonia")]
        public string Colonia { get; set; }

        [Required]
        [Display(Name = "CP")]
        public string CP { get; set; }
        
        [Required]
        [Display(Name = "Tel")]
        public string Tel { get; set; }
    }
}
