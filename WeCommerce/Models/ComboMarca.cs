using System.ComponentModel.DataAnnotations;

namespace WeCommerce.Models
{
    public class ComboMarca
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "La Descripcion es requerida")]
        [MaxLength(50)]
        public string Description { get; set; }
    }
}
