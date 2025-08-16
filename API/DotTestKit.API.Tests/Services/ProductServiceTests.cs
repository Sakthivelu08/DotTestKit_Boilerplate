using DotTestKit.API.Models;
using DotTestKit.API.Services;
using FluentAssertions;
using Xunit;
using System.Linq;

namespace DotTestKit.API.Tests.Services
{
    public class ProductServiceTests
    {
        private readonly ProductService _service;

        public ProductServiceTests()
        {
            _service = new ProductService();
        }

        [Fact]
        public void AddProduct_ShouldAddProductToList_WithIncrementedId()
        {
            // Arrange
            var product1 = new Product { Name = "Product 1", Price = 10 };
            var product2 = new Product { Name = "Product 2", Price = 20 };

            // Act
            var added1 = _service.AddProduct(product1);
            var added2 = _service.AddProduct(product2);
            var allProducts = _service.GetAllProducts().ToList();

            // Assert
            allProducts.Count.Should().Be(2);
            allProducts[0].Id.Should().Be(1);
            allProducts[1].Id.Should().Be(2);
            allProducts[1].Name.Should().Be("Product 2");
        }

        [Fact]
        public void GetAllProducts_ShouldReturnAllAddedProducts()
        {
            // Arrange
            _service.AddProduct(new Product { Name = "A", Price = 5 });
            _service.AddProduct(new Product { Name = "B", Price = 15 });

            // Act
            var products = _service.GetAllProducts().ToList();

            // Assert
            products.Count.Should().Be(2);
            products.Select(p => p.Name).Should().Contain(new[] { "A", "B" });
        }

        [Fact]
        public void GetProductById_ShouldReturnCorrectProduct_WhenExists()
        {
            // Arrange
            var added = _service.AddProduct(new Product { Name = "X", Price = 50 });

            // Act
            var result = _service.GetProductById(added.Id);

            // Assert
            result.Should().NotBeNull();
            result!.Name.Should().Be("X");
        }

        [Fact]
        public void GetProductById_ShouldReturnNull_WhenProductDoesNotExist()
        {
            // Act
            var result = _service.GetProductById(999);

            // Assert
            result.Should().BeNull();
        }
    }
}
