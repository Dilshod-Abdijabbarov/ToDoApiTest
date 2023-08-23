using AutoMapper;
using Domian.Entities;
using Services.DTOs.AddDueDateDTOs;
using Services.DTOs.AddFileDTOs;
using Services.DTOs.CategoryDTOs;
using Services.DTOs.RepeatTimeDTOs;
using Services.DTOs.TaskBaseDTOs;
using Services.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Configurations.Profiles
{
    public class MappingProFile : Profile
    {
        public MappingProFile()
        {
            CreateMap<AddDueDateForCreationDTO, AddDueDate>().ReverseMap();
            CreateMap<AddDueDateForViewDTOs, AddDueDate>().ReverseMap();

            CreateMap<AddFileForCreationDTOs, AddFile>().ReverseMap();
            CreateMap<AddFileForViewDTOs, AddFile>().ReverseMap();

            CreateMap<CategoryForCreationDTO, Category>().ReverseMap();
            CreateMap<CategoryForViewDTO, Category>().ReverseMap();

            CreateMap<RepeatTimeForCreationDTO, RepeatTime>().ReverseMap();
            CreateMap<RepeatTimeForViewDTO, RepeatTime>().ReverseMap();

            CreateMap<TaskBaseForViewDTO, TaskBase>().ReverseMap();
            CreateMap<TaskBaseForCreationDTO, TaskBase>().ReverseMap();

            CreateMap<UserForCreationDTO, User>().ReverseMap();
            CreateMap<UserForViewDTO, User>().ReverseMap();
            CreateMap<UserForPasswordChangeDTO, User>().ReverseMap();
        }

    }
}
