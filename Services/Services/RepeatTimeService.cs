using AutoMapper;
using Data.IRepositories;
using Domian.Entities;
using Services.DTOs.RepeatTimeDTOs;
using Services.DTOs.TaskBaseDTOs;
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
    public class RepeatTimeService : IRepeatTimeService
    {
        private readonly IRepeatTimeRepositoryAsync repeatTimeRepository;
        private readonly IMapper mapper;
        public RepeatTimeService(IRepeatTimeRepositoryAsync repeatTimeRepository, IMapper mapper)
        {
            this.repeatTimeRepository = repeatTimeRepository;
            this.mapper = mapper;

        }
        public async ValueTask<RepeatTimeForViewDTO> CreateAsync(RepeatTimeForCreationDTO repeatTimeForCreationDTO)
        {
            var repeatTime = await repeatTimeRepository.CreateAsync(mapper.Map<RepeatTime>(repeatTimeForCreationDTO));

            if (repeatTime == null)
                throw new ToDoException(400, "Create Not RepeatTime");
            await repeatTimeRepository.SaveChangesAsync();

            return mapper.Map<RepeatTimeForViewDTO>(repeatTime);
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDelete = await repeatTimeRepository.DeleteAsync(c => c.Id == id);

            if (!isDelete)
                throw new ToDoException(404, "RepatTime Not Delete");

            await repeatTimeRepository.SaveChangesAsync();

            return isDelete;
        }

        public async ValueTask<IEnumerable<RepeatTimeForViewDTO>> GetAllAsync(Expression<Func<RepeatTime, bool>> expression = null)
        {
            var repeatTime = repeatTimeRepository.GetAllAsync(expression: expression, isTracking: true);

            if (repeatTime == null)
                throw new ToDoException(404, "RepatTime Not fount");

            return mapper.Map<IEnumerable<RepeatTimeForViewDTO>>(repeatTime);
        }

        public async ValueTask<RepeatTimeForViewDTO> GetAsync(Expression<Func<RepeatTime, bool>> expression)
        {
            var task = await repeatTimeRepository.GetAsync(expression);

            if (task == null)
                throw new ToDoException(404, "RepeatTime Not fount");

            return mapper.Map<RepeatTimeForViewDTO>(task);
        }

        public async ValueTask<RepeatTimeForViewDTO> UpdateAsync(int id, RepeatTimeForCreationDTO repeatTimeForCreationDTO)
        {
            var repeatTime = await repeatTimeRepository.GetAsync(c => c.Id == id);

            if (repeatTime == null)
                throw new ToDoException(404, "RepeatTime Not Update");

            repeatTime = repeatTimeRepository.Update(mapper.Map(repeatTimeForCreationDTO, repeatTime));

            await repeatTimeRepository.SaveChangesAsync();

            return mapper.Map<RepeatTimeForViewDTO>(repeatTime);
        }
    }
}
