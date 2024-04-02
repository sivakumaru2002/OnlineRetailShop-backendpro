
using System.ComponentModel.DataAnnotations;

namespace OnlineRetailShop.Repository.Entity
{
    public class CreateProduct
    {
        
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public Boolean IsActive { get; set; }
    }
}
