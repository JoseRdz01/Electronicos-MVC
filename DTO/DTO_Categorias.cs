using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Categorias
    {
        [Key]
        public int ID_Categoria { get; set; }

        [Required]
        [Display(Name = "Nombre Categoria")]
        public string Nombre_Categoria { get; set; }

        [Required]
        [Display(Name = "Existencia Total")]
        public int Existencia_Total { get; set; }

    }
}
