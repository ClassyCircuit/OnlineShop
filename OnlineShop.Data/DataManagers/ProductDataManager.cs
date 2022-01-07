using OnlineShop.Data.Tables;

namespace OnlineShop.Data.DataManagers
{
    public class ProductDataManager
    {
        private readonly Context _context;

        public ProductDataManager(Context context)
        {
            _context = context;
        }

        public Category[] GetAllCategories()
        {
            return _context.Categories.ToArray();
        }

        public Product AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public void UpdateProductCode(int productId, string productCode)
        {
            var product = _context.Products.Single(t => t.Id == productId);
            product.ProductCode = productCode;
            _context.SaveChanges();
        }

        public Product[] GetAllProducts()
        {
            return _context.Products.ToArray();
        }
    }
}
