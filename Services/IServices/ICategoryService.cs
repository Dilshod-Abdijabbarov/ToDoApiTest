using Domian.Entities;
using Services.DTOs.CategoryDTOs;
using Services.DTOs.TaskBaseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface ICategoryService
    {
        ValueTask<CategoryForViewDTO> CreateAsync(CategoryForCreationDTO categoryForCreationDTO);

        ValueTask<CategoryForViewDTO> UpdateAsync(int id, CategoryForCreationDTO categoryForCreationDTO);

        ValueTask<bool> DeleteAsync(int id);

        ValueTask<CategoryForViewDTO> GetAsync(Expression<Func<Category, bool>> expression);

        ValueTask<IEnumerable<CategoryForViewDTO>> GetAllAsync(
            Expression<Func<Category, bool>> expression = null);
    }
}
