

using System.ComponentModel.DataAnnotations;

namespace OnlineRetailShop.Repository.Entity
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }

        [Required]
        public string? ProductName { get; set; }

        public int Quantity { get; set; }

        public Boolean IsActive { get; set; }
    }
}
