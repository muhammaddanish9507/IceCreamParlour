using System.ComponentModel.DataAnnotations;

namespace IceCreamParlour.Models
{
    public class ProductViewModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public IFormFile Photo { get; set; } = null!;
        [Required]
        public string? B_name { get; set; }
        public string? B_Desc { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
