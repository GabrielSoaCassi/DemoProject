using System;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoDemo.Domain.Entities;
using ProjetoDemo.Domain.Validation;
using Xunit;

namespace ProjetoDemo.Domain.Tests
{
    public class ProductUnitTest
    {
        [Fact]
        public void CreateProduct_WithValidParamente_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "Product Image");
            action.Should().NotThrow<DomainValidationException>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m, 99, "Product Image");
            action.Should().Throw<DomainValidationException>()
                .WithMessage("Invalid Id value.");
        }

        [Fact]
        public void CreateProduct_InvalidName_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 9.99m, 99, "Product Image");
            action.Should().Throw<DomainValidationException>()
                .WithMessage("Invalid name. name too short, minimum 3 characters.");
        }

        [Fact]
        public void CreateProduct_LongImageName_DomainExceptionLongImageName()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99,
                "Product Image toooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo loooooooooooooooooooooooooooooooooooooooooooooooooooooooongggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg");
            action.Should().Throw<DomainValidationException>()
                .WithMessage("Invalid image name, too long, maximum 250 characters.");
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99,null);
            action.Should().NotThrow<DomainValidationException>();
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);
            action.Should().NotThrow<NullReferenceException>();
        }

        [Fact]
        public void CreateProduct_WithEmptyImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, string.Empty);
            action.Should().NotThrow<DomainValidationException>();
        }

        [Fact]
        public void CreateProduct_WithInvalidPriceValue_DomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", -9.99m, 99, string.Empty);
            action.Should().Throw<DomainValidationException>()
                .WithMessage("Invalid price value.");
        }


        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, value, string.Empty);
            action.Should()
                .Throw<DomainValidationException>()
                .WithMessage("Invalid Stock value.");
        }
    }
}
