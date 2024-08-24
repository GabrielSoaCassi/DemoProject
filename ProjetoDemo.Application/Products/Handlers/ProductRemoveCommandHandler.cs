using MediatR;
using ProjetoDemo.Application.Products.Commands;
using ProjetoDemo.Domain.Entities;
using ProjetoDemo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoDemo.Application.Products.Handlers
{
    public class ProductRemoveCommandHandler: IRequestHandler<ProductRemoveCommand,Product>
    {
        private readonly IProductRepository _productRepository;

        public ProductRemoveCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            if (product == null) 
            {
                throw new ApplicationException("Error: data could not be found");
            }
            else
            {
                var result = await _productRepository.RemoveAsync(product);
                return result;
            }
        }
    }
}
