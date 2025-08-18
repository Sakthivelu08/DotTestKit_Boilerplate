using DotTestKit.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace DotTestKit.API.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product? GetProductById(int id);
        Product AddProduct(Product product);
    }

    public class ProductService : IProductService
    {
        private readonly List<Product> _products = new();

        public IEnumerable<Product> GetAllProducts()
        {
            return _products;
        }

        public Product? GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public Product AddProduct(Product product)
        {
            product.Id = _products.Count + 1;
            _products.Add(product);
            return product;
        }
    }
}
