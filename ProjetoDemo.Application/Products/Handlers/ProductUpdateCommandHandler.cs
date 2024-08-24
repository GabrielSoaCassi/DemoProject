using MediatR;
using ProjetoDemo.Application.Products.Commands;
using ProjetoDemo.Domain.Entities;
using ProjetoDemo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoDemo.Application.Products.Handlers
{
    public class ProductUpdateCommandHandler:IRequestHandler<ProductUpdateCommand,Product>
    {
        private readonly IProductRepository _productRepository;

        public ProductUpdateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> Handle(ProductUpdateCommand request,CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            if(product == null)
            {
                throw new ApplicationException("Error : data could not be found");
            }
            else
            {
                product.Update(request.Name, request.Description, request.Price, request.Stock, request.Image, request.CategoryId);
                return await _productRepository.UpdateAsync(product);
            }
        }
    }
}
