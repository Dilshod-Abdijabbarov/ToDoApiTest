﻿using AutoMapper;
using Data.IRepositories;
using Domian.Entities;
using Services.DTOs.AddFileDTOs;
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
    public class AddFileService : IAddFileService
    {
        private readonly IAddFileRepositoryAsync addFileRepositoryAsync;
        private readonly IMapper mapper;
        public AddFileService(IAddFileRepositoryAsync addFileRepositoryAsync,IMapper mapper)
        {
            this.addFileRepositoryAsync = addFileRepositoryAsync;
            this.mapper = mapper;
        }
        public async ValueTask<AddFileForViewDTOs> CreateAsync(AddFileForCreationDTOs addFileForCreationDTO)
        {
            var addFile = await addFileRepositoryAsync.CreateAsync(mapper.Map<AddFile>(addFileForCreationDTO));

            if (addFile == null)
                throw new ToDoException(400, "AddFile not");

            await addFileRepositoryAsync.SaveChangesAsync();

            return mapper.Map<AddFileForViewDTOs>(addFile);
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDelete = await addFileRepositoryAsync.DeleteAsync(c => c.Id == id);

            if (!isDelete)
                throw new ToDoException(404, "File Not Delete");

            await addFileRepositoryAsync.SaveChangesAsync();

            return isDelete;
        }

        public async ValueTask<IEnumerable<AddFileForViewDTOs>> GetAllAsync(Expression<Func<AddFile, bool>> expression = null)
        {
            var filies = addFileRepositoryAsync.GetAllAsync(expression: expression);

            if (filies  == null)
                throw new ToDoException(404, "File Not fount");

            return mapper.Map<IEnumerable<AddFileForViewDTOs>>(filies);
        }

        public async ValueTask<AddFileForViewDTOs> GetAsync(Expression<Func<AddFile, bool>> expression)
        {
            var file = await addFileRepositoryAsync.GetAsync(expression);

            if (file == null)
                throw new ToDoException(404, "File Not fount");

            return mapper.Map<AddFileForViewDTOs>(file);
        }

        public async ValueTask<AddFileForViewDTOs> UpdateAsync(int id, AddFileForCreationDTOs addFileForCreationDTO)
        {
            var file = await addFileRepositoryAsync.GetAsync(c => c.Id == id);

            if (file == null)
                throw new ToDoException(404, "File Not Update");

            file = addFileRepositoryAsync.Update(mapper.Map(addFileForCreationDTO, file));

            await addFileRepositoryAsync.SaveChangesAsync();

            return mapper.Map<AddFileForViewDTOs>(file);
        }
    }
}
