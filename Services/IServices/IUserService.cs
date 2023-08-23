using Domian.Entities;
using Services.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IUserService
    {
        ValueTask<UserForViewDTO> CreateAsync(UserForCreationDTO userForCreationDTO);

        ValueTask<UserForViewDTO> UpdateAsync(int id, UserForCreationDTO userForCreationDTO);

        ValueTask<bool> DeleteAsync(int id);

        ValueTask<UserForViewDTO> GetAsync(Expression<Func<User, bool>> expression);

        ValueTask<IEnumerable<UserForViewDTO>> GetAllAsync(            
            Expression<Func<User, bool>> expression = null);

        ValueTask<bool> ChangePasswordAsync(UserForPasswordChangeDTO userForChangePasswordDTO);
    }
}
