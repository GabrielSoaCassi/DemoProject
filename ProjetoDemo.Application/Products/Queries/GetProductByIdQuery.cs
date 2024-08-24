using MediatR;
using ProjetoDemo.Domain.Entities;

namespace ProjetoDemo.Application.Products.Queries
{
    public class GetProductByIdQuery:IRequest<Product>
    {
        public int Id { get; set; }

        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
