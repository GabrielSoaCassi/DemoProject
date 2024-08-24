using ProjetoDemo.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDemo.Domain.Entities
{
    public sealed class Product:BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image {  get; private set; }
        public int CategoryId { get; set; }
        public  Category Category { get; set; }

        public Product(int id,string name, string description, decimal price, int stock, string image)
        {
            DomainValidationException.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description,price,stock,image);
        }

        public void Update(string name, string description, decimal price, int stock, string image,int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        private void ValidateDomain(string name,string description,decimal price,int stock,string image)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is Required.");
            DomainValidationException.When(name.Length < 3,
                    "Invalid name. name too short, minimum 3 characters.");
            DomainValidationException.When(string.IsNullOrEmpty(description),
                "Invalid description, too short, minimum 5 characteres.");
            DomainValidationException.When(description.Length < 5,
                "Invalid description, too short, minimum 5 characteres.");
            DomainValidationException.When(price < 0,
                "Invalid price value.");
            DomainValidationException.When(stock < 0,"Invalid Stock value.");
            DomainValidationException.When(image?.Length  > 250,
                "Invalid image name, too long, maximum 250 characters.");
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
    }
}
