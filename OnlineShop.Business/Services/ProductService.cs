using OnlineShop.Business.Exceptions;
using OnlineShop.Business.Helpers;
using OnlineShop.Data.DataManagers;
using OnlineShop.Data.Structures;
using OnlineShop.Data.Tables;

namespace OnlineShop.Business.Services
{
    public class ProductService
    {
        private readonly ProductDataManager _productDm;
        private readonly HashingHelper _hashingHelper;

        public ProductService(ProductDataManager productDm, HashingHelper hashingHelper)
        {
            _productDm = productDm;
            _hashingHelper = hashingHelper;
        }

        public Category[] GetProductCategories()
        {
            return _productDm.GetAllCategories();
        }

        public LinkedListCircular<string> GetTopProductImages()
        {
            var products = _productDm.GetAllProducts();
            var result = new LinkedListCircular<string>();
            foreach (var product in products)
            {
                result.AddHead(product.ImagePath);
            }

            return result;
        }

        public void AddProduct(Product product)
        {
            if (product.Price <= 0)
            {
                throw new InvalidPriceException("Product price must be greater than zero");
            }

            var result = _productDm.AddProduct(product);
            product.ProductCode = _hashingHelper.Encode(result.Id);

            _productDm.UpdateProductCode(productId: result.Id, productCode: product.ProductCode);

        }
    }
}
