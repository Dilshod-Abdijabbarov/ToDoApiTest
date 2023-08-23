using Domian.Entities;
using Services.DTOs.TaskBaseDTOs;
using Services.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface ITaskBaseService
    {
        ValueTask<TaskBaseForViewDTO> CreateAsync(TaskBaseForCreationDTO taskBaseForCreationDTO);

        ValueTask<TaskBaseForViewDTO> UpdateAsync(int id, TaskBaseForCreationDTO taskBaseForCreationDTO);

        ValueTask<bool> DeleteAsync(int id);

        ValueTask<TaskBaseForViewDTO> GetAsync(Expression<Func<TaskBase, bool>> expression);

        ValueTask<IEnumerable<TaskBaseForViewDTO>> GetAllAsync(
            Expression<Func<TaskBase, bool>> expression = null);
    }
}
