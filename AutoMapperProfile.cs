using AutoMapper;
using TimeTrackerAPI.Dto.Employee;
using TimeTrackerAPI.Dto.WorkEntry;
using TimeTrackerAPI.Models;

namespace TimeTrackerAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            // Employee mapping
            CreateMap<Employee, EmployeeReadDto>()
            .ForMember(dest => dest.WorkEntries, opt => opt.MapFrom(src => src.WorkEntries));
            CreateMap<EmployeeCreateDto, Employee>();
            CreateMap<EmployeeUpdateDto, Employee>();

            // WorkEntry mapping
            CreateMap<WorkEntry, WorkEntryReadDto>()
            .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Employee.FullName));
            CreateMap<WorkEntryCreateDto, WorkEntry>();
            CreateMap<WorkEntryUpdateDto, WorkEntry>();
            CreateMap<WorkEntry, WorkEntrySimpleDto>();
        }
    }
}
