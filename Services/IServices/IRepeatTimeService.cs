using Domian.Entities;
using Services.DTOs.RepeatTimeDTOs;
using Services.DTOs.TaskBaseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IRepeatTimeService
    {
        ValueTask<RepeatTimeForViewDTO> CreateAsync(RepeatTimeForCreationDTO repeatTimeForCreationDTO);

        ValueTask<RepeatTimeForViewDTO> UpdateAsync(int id, RepeatTimeForCreationDTO repeatTimeForCreationDTO);

        ValueTask<bool> DeleteAsync(int id);

        ValueTask<RepeatTimeForViewDTO> GetAsync(Expression<Func<RepeatTime, bool>> expression);

        ValueTask<IEnumerable<RepeatTimeForViewDTO>> GetAllAsync(
            Expression<Func<RepeatTime, bool>> expression = null);
    }
}
