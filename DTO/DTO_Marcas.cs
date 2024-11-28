using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class DTO_Marcas
    {
        [Key]
        public int ID_Marca { get; set; }

        [Required]
        [Display(Name = "Nombre Marca")]
        public string Nombre_Marca { get; set; }

        
    }
}
