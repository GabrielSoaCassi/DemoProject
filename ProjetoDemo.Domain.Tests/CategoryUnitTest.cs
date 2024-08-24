using FluentAssertions;
using ProjetoDemo.Domain.Entities;
using ProjetoDemo.Domain.Validation;
using System;
using Xunit;

namespace ProjetoDemo.Domain.Tests
{
    public class CategoryTests
    {
        [Fact]
        public void CreateCategory_WithValidParamente_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should().NotThrow<DomainValidationException>();
        }

        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should().Throw<DomainValidationException>()
                .WithMessage("Invalid Id value.");
        }

        [Fact]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, string.Empty);
            action.Should().Throw<DomainValidationException>()
                .WithMessage("Invalid name. Name is Required.");
        }

        [Fact]
        public void CreateCategory_NullNameValue_DomainException()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<DomainValidationException>();
        }

        [Fact]
        public void CreateCategory_InvalidName_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should().Throw<DomainValidationException>()
                .WithMessage("Invalid name. name too short, minimum 3 characters.");
        }
    }
}
