using AutoMapper;
using MediatR;
using ProjetoDemo.Application.DTOs;
using ProjetoDemo.Application.Products.Commands;
using ProjetoDemo.Application.Products.Handlers;
using ProjetoDemo.Application.Products.Queries;
using ProjetoDemo.Domain.Entities;
using ProjetoDemo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDemo.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        
        public ProductService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator ??
                throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper;
        }

        public async Task AddAsync(ProductDTO product)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(product);
            await _mediator.Send(productCreateCommand);
        }

        public async Task<ProductDTO> GetByIdAsync(int? id)
        {
            var productQuery = new GetProductByIdQuery(id.Value);
            if (productQuery == null)
                throw new ArgumentNullException(nameof(productQuery));
            var productEntity = await _mediator.Send(productQuery);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var productsQuery = new GetProductsQuery();
            var result = await _mediator.Send(productsQuery);
            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task RemoveAsync(int? id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id.Value);
            if(productRemoveCommand == null)
                throw new ArgumentException(nameof(productRemoveCommand));
            await _mediator.Send(productRemoveCommand);
        }

        public async Task UpdateAsync(ProductDTO product)
        {
            var productEntity = _mapper.Map<ProductUpdateCommand>(product);
            await _mediator.Send(productEntity);
        }
    }
}
