using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Protuctos
    {
        [Key]
        public int ID_Producto { get; set; }

        [Required]
        [Display(Name = "Nombre Producto")]
        public string Nombre_Producto { get; set; }

        [Required]
        [Display(Name = "Marca ID")]
        public int Marca_ID { get; set; }

        [Required]
        [Display(Name = "Categoria ID")]
        public int Categoria_ID { get; set; }

        [Required]
        [Display(Name = "Existencia")]
        public string Existencia { get; set; }
        
        [Required]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Precio")]
        public double Precio { get; set; }

        [Required]
        [Display(Name = "URL Imagen")]
        public string URL_Imagen { get; set; }

        [Required]
        [Display(Name = "Procesador")]
        public string Procesador { get; set; }

        [Required]
        [Display(Name = "RAM")]
        public string RAM { get; set; }

        [Required]
        [Display(Name = "Disco Duro")]
        public string DiscoDuro { get; set; }

    }
}
