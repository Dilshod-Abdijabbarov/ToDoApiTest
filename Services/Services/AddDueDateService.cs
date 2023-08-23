using AutoMapper;
using Data.IRepositories;
using Data.Repositories;
using Domian.Entities;
using Services.DTOs.AddDueDateDTOs;
using Services.DTOs.AddFileDTOs;
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
    public class AddDueDateService : IAddDueDateService
    {
        private readonly IAddDueDateRepositoryAsync dueDateRepositoryAsync;
        private readonly IMapper mapper;
        public AddDueDateService(IAddDueDateRepositoryAsync dueDateRepositoryAsync,IMapper mapper)
        {
            this.dueDateRepositoryAsync = dueDateRepositoryAsync;
            this.mapper = mapper;
        }
        public async ValueTask<AddDueDateForViewDTOs> CreateAsync(AddDueDateForCreationDTO addDueDateForCreationDTO)
        {
            var addDueDate = await dueDateRepositoryAsync.CreateAsync(mapper.Map<AddDueDate>(addDueDateForCreationDTO));

            if (addDueDate==null)
                throw new ToDoException(400, "AddDueDate not Add");

            await dueDateRepositoryAsync.SaveChangesAsync();

            return mapper.Map<AddDueDateForViewDTOs>(addDueDate); 
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDelete = await dueDateRepositoryAsync.DeleteAsync(c => c.Id == id);

            if (!isDelete)
                throw new ToDoException(404, "AddDueDate Not Delete");

            await dueDateRepositoryAsync.SaveChangesAsync();

            return isDelete;
        }

        public async ValueTask<IEnumerable<AddDueDateForViewDTOs>> GetAllAsync(Expression<Func<AddDueDate, bool>> expression = null)
        {
            var addDueDate = dueDateRepositoryAsync.GetAllAsync(expression: expression, isTracking: true);

            if (addDueDate == null)
                throw new ToDoException(404, "AddDueDate Not fount");

            return mapper.Map<IEnumerable<AddDueDateForViewDTOs>>(addDueDate);
        }

        public async ValueTask<AddDueDateForViewDTOs> GetAsync(Expression<Func<AddDueDate, bool>> expression)
        {
            var addDueDate = await dueDateRepositoryAsync.GetAsync(expression);

            if (addDueDate == null)
                throw new ToDoException(404, "File Not fount");

            return mapper.Map<AddDueDateForViewDTOs>(addDueDate);
        }

        public async ValueTask<AddDueDateForViewDTOs> UpdateAsync(int id, AddDueDateForCreationDTO addDueDateForCreationDTO)
        {
            var addDueDate = await dueDateRepositoryAsync.GetAsync(c => c.Id == id);

            if (addDueDate == null)
                throw new ToDoException(404, "File Not Update");

            addDueDate = dueDateRepositoryAsync.Update(mapper.Map(addDueDateForCreationDTO, addDueDate));

            await dueDateRepositoryAsync.SaveChangesAsync();

            return mapper.Map<AddDueDateForViewDTOs>(addDueDate);
        }
    }
}
