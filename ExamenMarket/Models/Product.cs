using System.ComponentModel.DataAnnotations;

namespace ExamenMarket.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El precio del producto es obligatorio")]
        public double Price { get; set; }

        [Required(ErrorMessage = "La fecha de vencimiento es obligatorio")]
        public DateTime ExpirationDate { get; set; }
    }
}
