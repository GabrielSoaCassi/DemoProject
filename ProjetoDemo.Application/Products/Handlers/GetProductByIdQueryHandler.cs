using MediatR;
using ProjetoDemo.Application.Products.Queries;
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
    internal class GetProductByIdQueryHandler: IRequestHandler<GetProductByIdQuery,Product>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetByIdAsync(request.Id);
        }
    }
}
