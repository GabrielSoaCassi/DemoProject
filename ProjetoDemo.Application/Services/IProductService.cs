using ProjetoDemo.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDemo.Application.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProductsAsync();
        Task<ProductDTO> GetByIdAsync(int? id);
        Task AddAsync(ProductDTO category);
        Task UpdateAsync(ProductDTO category);
        Task RemoveAsync(int? id);
    }
}
