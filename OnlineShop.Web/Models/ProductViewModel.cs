using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnlineShop.Web.Models
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public string CategoryId { get; set; }
        public IFormFile Image { get; set; }
    }
}
