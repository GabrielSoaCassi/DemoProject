using MediatR;
using ProjetoDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDemo.Application.Products.Queries
{
    public class GetProductsQuery:IRequest<IEnumerable<Product>>
    {
    }
}
