using AutoMapper;
using ProjetoDemo.Application.DTOs;
using ProjetoDemo.Domain.Entities;
using ProjetoDemo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoDemo.Application.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository ?? 
                throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper;
        }

        public async Task AddAsync(CategoryDTO category)
        {
            var categoryEntity = _mapper.Map<Category>(category);
            await _categoryRepository.CreateAsync(categoryEntity);
        }

        public async Task<CategoryDTO> GetByIdAsync(int id)
        {
            var categoryEntity = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(categoryEntity);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            var categoriesEntity = await _categoryRepository.GetCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);

        }

        public async Task RemoveAsync(int? id)
        {
            var categoryEntity =  _categoryRepository.GetByIdAsync(id).Result;
            await _categoryRepository.RemoveAsync(categoryEntity);
        }

        public async Task UpdateAsync(CategoryDTO category)
        {
            var categoryEntity = _mapper.Map<Category>(category);
            await _categoryRepository.UpdateAsync(categoryEntity);
        }
    }
}
