using Domian.Entities;
using Services.DTOs.AddFileDTOs;
using Services.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IAddFileService
    {
        ValueTask<AddFileForViewDTOs> CreateAsync(AddFileForCreationDTOs addFileForCreationDTO);

        ValueTask<AddFileForViewDTOs> UpdateAsync(int id, AddFileForCreationDTOs addFileForCreationDTO);

        ValueTask<bool> DeleteAsync(int id);

        ValueTask<AddFileForViewDTOs> GetAsync(Expression<Func<AddFile, bool>> expression);

        ValueTask<IEnumerable<AddFileForViewDTOs>> GetAllAsync(
            Expression<Func<AddFile, bool>> expression = null);
    }
}
