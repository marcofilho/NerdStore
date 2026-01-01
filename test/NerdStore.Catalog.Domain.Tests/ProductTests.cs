using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalog.Domain.Tests
{
    public class ProductTests
    {
        [Fact]
        public void Product_Validate_ValidationsShouldReturnExceptions()
        {
            //Arrange & Act & Assert

            var ex = Assert.Throws<DomainException>(() =>
                new Product(string.Empty, "Description", false, 0, Guid.NewGuid(), DateTime.Now, "New Image", new Dimension(1, 1, 1)));

            Assert.Equal("The field Name can't be empty.", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Product("Product Name", string.Empty, false, 0, Guid.NewGuid(), DateTime.Now, "New Image", new Dimension(1, 1, 1)));

            Assert.Equal("The field Description can't be empty.", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Product("Product Name", "Description", false, 0, Guid.NewGuid(), DateTime.Now, "New Image", new Dimension(1, 1, 1)));

            Assert.Equal("The field Price of the Product can't be less or equals 0.", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Product("Product Name", "Description", false, 10, Guid.Empty, DateTime.Now, "New Image", new Dimension(1, 1, 1)));

            Assert.Equal("The field Product Category can't be empty.", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Product("Product Name", "Description", false, 10, Guid.NewGuid(), DateTime.Now, string.Empty, new Dimension(1, 1, 1)));

            Assert.Equal("The field Image can't be empty.", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Product("Product Name", "Description", false, 10, Guid.NewGuid(), DateTime.Now, "Image", new Dimension(0, 1, 1)));

            Assert.Equal("The field Height must be greater than zero.", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Product("Product Name", "Description", false, 10, Guid.NewGuid(), DateTime.Now, "Image", new Dimension(1, 0, 1)));

            Assert.Equal("The field Width must be greater than zero.", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Product("Product Name", "Description", false, 10, Guid.NewGuid(), DateTime.Now, "Image", new Dimension(1, 1, 0)));

            Assert.Equal("The field Depth must be greater than zero.", ex.Message);

        }
    }
}