using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Service.DTOs.Category;
using Service.Interfaces;
using Service.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Category> _categoryRepository;
        public CategoryService(IGenericRepository<Category> categoryRepository, IMapper mapper)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryDto> Create(CreateCategoryDto category)
        {
            var Category = _mapper.Map<Category>(category);
            await _categoryRepository.Add(Category);
            var result = _mapper.Map<CategoryDto>(Category);
            return result;

        }

        public  async Task<bool> Delete(int id)
        {
            var Cat = await _categoryRepository.GetByIdAsync(id);
            if (Cat == null) return false;
            await _categoryRepository.Delete(Cat);
            return true;
        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return result;
        }

        public async Task<CategoryDto?> GetById(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) return null;
            var result = _mapper.Map<CategoryDto>(category);
            return result;
        }

        public async Task<CategoryDto?> Update(UpdateCategoryDto category)
        {
            var Cat = await _categoryRepository.GetByIdAsync(category.Id);
            if (Cat == null) return null;
            _mapper.Map(category,Cat);
            await _categoryRepository.Update(Cat);
            var result = _mapper.Map<CategoryDto>(Cat);
            return result;
        }
    }
}
