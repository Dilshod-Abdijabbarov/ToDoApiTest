using Domian.Entities;
using Services.DTOs.AddDueDateDTOs;
using Services.DTOs.AddFileDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IAddDueDateService
    {
        ValueTask<AddDueDateForViewDTOs> CreateAsync(AddDueDateForCreationDTO addDueDateForCreationDTO);

        ValueTask<AddDueDateForViewDTOs> UpdateAsync(int id, AddDueDateForCreationDTO addDueDateForCreationDTO);

        ValueTask<bool> DeleteAsync(int id);

        ValueTask<AddDueDateForViewDTOs> GetAsync(Expression<Func<AddDueDate, bool>> expression);

        ValueTask<IEnumerable<AddDueDateForViewDTOs>> GetAllAsync(
            Expression<Func<AddDueDate, bool>> expression = null);
    }
}
