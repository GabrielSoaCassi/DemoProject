using ProjetoDemo.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDemo.Domain.Entities
{
    public sealed class Category:BaseEntity
    {
        public string Name{ get; private set; }

        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainValidationException.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(name);
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is Required.");
            DomainValidationException.When(name.Length < 3,
                "Invalid name. name too short, minimum 3 characters.");
            Name = name;
        }

        public ICollection<Product> Products { get; set; }
    }
}
