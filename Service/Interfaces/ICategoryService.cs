using Domain.Entities;
using Service.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryDto>> GetAll();
        public Task<CategoryDto?> GetById(int id);
        public Task<CategoryDto> Create(CreateCategoryDto category);
        public Task<CategoryDto?> Update(UpdateCategoryDto category);
        public Task<bool> Delete(int id);

    }
}
