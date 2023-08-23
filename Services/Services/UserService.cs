using AutoMapper;
using Data.IRepositories;
using Domian.Entities;
using Microsoft.EntityFrameworkCore;
using Services.DTOs.UserDTOs;
using Services.Exceptions;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepositoryAsync userRepository;
        private readonly IMapper mapper;
        public UserService(IUserRepositoryAsync userRepository,IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async ValueTask<UserForViewDTO> CreateAsync(UserForCreationDTO userForCreationDTO)
        {
            var alreadyuser = await userRepository.GetAsync(c => c.FirstName == userForCreationDTO.FirstName);

            if (alreadyuser != null)
                throw new ToDoException(400, "User with such username already exist");

            var user = await userRepository.CreateAsync(mapper.Map<User>(userForCreationDTO));

            await userRepository.SaveChangesAsync();

            return mapper.Map<UserForViewDTO>(user);
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDelete = await userRepository.DeleteAsync(c => c.Id == id);

            if (!isDelete)
                throw new ToDoException(404, "User Not Delete");

            await userRepository.SaveChangesAsync();

            return isDelete;
        }

        public async ValueTask<IEnumerable<UserForViewDTO>> GetAllAsync(Expression<Func<User, bool>> expression = null)      
        {
            var users = userRepository.GetAllAsync(expression: expression, isTracking: false, includes: new string[] {"Tasks"});

            if (users == null)
                throw new ToDoException(404, "Users Not fount");

            return mapper.Map<IEnumerable<UserForViewDTO>>(await users.ToListAsync());
        }
   
        public async ValueTask<UserForViewDTO> GetAsync(Expression<Func<User, bool>> expression)
        {
            var user = await userRepository.GetAsync(expression, includes: new string[] { "Tasks" });

            if (user == null)
                throw new ToDoException(404, "User Not fount");

            return mapper.Map<UserForViewDTO>(user);
        }

        public async ValueTask<UserForViewDTO> UpdateAsync(int id, UserForCreationDTO userForCreationDTO)
        {
            var userData = await userRepository.GetAsync(c => c.Id == id);

            if (userData == null)
                throw new ToDoException(404, "User Not Update");

            userData = userRepository.Update(mapper.Map(userForCreationDTO, userData));

            await userRepository.SaveChangesAsync();

            return mapper.Map<UserForViewDTO>(userData);
        }

        public async ValueTask<bool> ChangePasswordAsync(UserForPasswordChangeDTO userForChangePasswordDTO)
        {
            var user = await userRepository.GetAsync(x => x.Email.Equals(userForChangePasswordDTO.Email) && x.Password.Equals(userForChangePasswordDTO.OldPassword));

            if (user == null)
                throw new ToDoException(400, "User Not Found");

            if (user.Password == userForChangePasswordDTO.NewPassword)
                throw new ToDoException(400, "Password in Incorrect");

            user.Password = userForChangePasswordDTO.NewPassword;

            userRepository.Update(user);

            await userRepository.SaveChangesAsync();

            return true;
        }
    }
}
