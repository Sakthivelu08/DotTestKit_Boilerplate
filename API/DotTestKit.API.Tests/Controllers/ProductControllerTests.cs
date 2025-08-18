using DotTestKit.API.Controllers;
using DotTestKit.API.Models;
using DotTestKit.API.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using System.Collections.Generic;

namespace DotTestKit.API.Tests.Controllers
{
    public class ProductControllerTests
    {
        private readonly Mock<IProductService> _mockService;
        private readonly ProductController _controller;

        public ProductControllerTests()
        {
            _mockService = new Mock<IProductService>();
            _controller = new ProductController(_mockService.Object);
        }

        [Fact]
        public void GetAll_ShouldReturnOkWithProducts_WhenProductsExist()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "A", Price = 10 }
            };
            _mockService.Setup(s => s.GetAllProducts()).Returns(products);

            var result = _controller.GetAll() as OkObjectResult;

            result.Should().NotBeNull();
            result!.StatusCode.Should().Be(200);
            result.Value.Should().BeEquivalentTo(products);
        }

        [Fact]
        public void GetAll_ShouldReturnOkWithEmptyList_WhenNoProducts()
        {
            _mockService.Setup(s => s.GetAllProducts()).Returns(new List<Product>());

            var result = _controller.GetAll() as OkObjectResult;

            result.Should().NotBeNull();
            result!.Value.Should().BeEquivalentTo(new List<Product>());
        }

        [Fact]
        public void GetById_ShouldReturnProduct_WhenExists()
        {
            var product = new Product { Id = 1, Name = "A", Price = 10 };
            _mockService.Setup(s => s.GetProductById(1)).Returns(product);

            var result = _controller.GetById(1) as OkObjectResult;

            result.Should().NotBeNull();
            result!.Value.Should().BeEquivalentTo(product);
        }

        [Fact]
        public void GetById_ShouldReturnNotFound_WhenDoesNotExist()
        {
            _mockService.Setup(s => s.GetProductById(999)).Returns((Product?)null);

            var result = _controller.GetById(999);

            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public void Add_ShouldReturnCreatedAtAction_WithAddedProduct()
        {
            var product = new Product { Name = "New", Price = 50 };
            var added = new Product { Id = 1, Name = "New", Price = 50 };

            _mockService.Setup(s => s.AddProduct(product)).Returns(added);

            var result = _controller.Add(product) as CreatedAtActionResult;

            result.Should().NotBeNull();
            result!.ActionName.Should().Be(nameof(_controller.GetById));
            result.Value.Should().BeEquivalentTo(added);
        }

        [Fact]
        public void Add_ShouldHandleMultipleAdds_Correctly()
        {
            var product1 = new Product { Name = "P1", Price = 10 };
            var product2 = new Product { Name = "P2", Price = 20 };

            _mockService.SetupSequence(s => s.AddProduct(It.IsAny<Product>()))
                        .Returns(new Product { Id = 1, Name = "P1", Price = 10 })
                        .Returns(new Product { Id = 2, Name = "P2", Price = 20 });

            var result1 = _controller.Add(product1) as CreatedAtActionResult;
            var result2 = _controller.Add(product2) as CreatedAtActionResult;

            result1!.Value.Should().BeEquivalentTo(new Product { Id = 1, Name = "P1", Price = 10 });
            result2!.Value.Should().BeEquivalentTo(new Product { Id = 2, Name = "P2", Price = 20 });
        }
    }
}
