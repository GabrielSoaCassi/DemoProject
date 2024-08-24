using ProjetoDemo.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoDemo.Application.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();
        Task<CategoryDTO> GetByIdAsync(int id);
        Task AddAsync(CategoryDTO category);
        Task UpdateAsync(CategoryDTO category);
        Task RemoveAsync(int? id);
    }
}
