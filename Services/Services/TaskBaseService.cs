using AutoMapper;
using Data.IRepositories;
using Domian.Entities;
using Microsoft.EntityFrameworkCore;
using Services.DTOs.TaskBaseDTOs;
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
    public class TaskBaseService : ITaskBaseService
    {
        private readonly ITaskRepositoryAsync taskRepository;
        private readonly IMapper mapper;
        public TaskBaseService(ITaskRepositoryAsync taskRepository,IMapper mapper)
        {
            this.taskRepository = taskRepository;
            this.mapper = mapper;
        }
        public async ValueTask<TaskBaseForViewDTO> CreateAsync(TaskBaseForCreationDTO taskBaseForCreationDTO)
        {
            var alreadytask = await taskRepository.GetAsync(c => c.TaskName==taskBaseForCreationDTO.TaskName);

            if (alreadytask != null)
                throw new ToDoException(400, "Task with such taskname already exist");

            var task = await taskRepository.CreateAsync(mapper.Map<TaskBase>(taskBaseForCreationDTO));

            await taskRepository.SaveChangesAsync();

            return mapper.Map<TaskBaseForViewDTO>(task);
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDelete = await taskRepository.DeleteAsync(c => c.Id == id);

            if (!isDelete)
                throw new ToDoException(404, "Task Not Delete");

            await taskRepository.SaveChangesAsync();

            return isDelete;
        }

        public async ValueTask<IEnumerable<TaskBaseForViewDTO>> GetAllAsync(Expression<Func<TaskBase, bool>> expression = null)
        {
            var tasks =  taskRepository.GetAllAsync(expression: expression, isTracking: false);

            if (tasks == null)
                throw new ToDoException(404, "Tasks Not fount");

            return mapper.Map<IEnumerable<TaskBaseForViewDTO>>(await tasks.ToListAsync());
        }

        public async ValueTask<TaskBaseForViewDTO> GetAsync(Expression<Func<TaskBase, bool>> expression)
        {
            var task = await taskRepository.GetAsync(expression);

            if (task == null)
                throw new ToDoException(404, "Task Not fount");

            return mapper.Map<TaskBaseForViewDTO>(task);
        }

        public async ValueTask<TaskBaseForViewDTO> UpdateAsync(int id, TaskBaseForCreationDTO taskBaseForCreationDTO)
        {
            var taskData = await taskRepository.GetAsync(c => c.Id == id);

            if (taskData == null)
                throw new ToDoException(404, "Task Not Update");

            taskData = taskRepository.Update(mapper.Map(taskBaseForCreationDTO, taskData));

            await taskRepository.SaveChangesAsync();

            return mapper.Map<TaskBaseForViewDTO>(taskData);
        }
    }
}
