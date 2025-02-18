using AutoMapper;
using DL.SDC.Models.DbModel;
using DTO.Models;
using Microsoft.Extensions.DependencyInjection;
using Employee = DL.SDC.Models.DbModel.Employee;
using EmployeeRole = DL.SDC.Models.DbModel.EmployeeRole;

namespace Moj.Repositories.Reserves.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            CreateMap<Employee, DTO.Models.Employee>()
                 .ForMember(d => d.ManagerName, opt => opt.MapFrom(src => src.Manager != null ? src.Manager.Name : null))
                 .ForMember(d => d.RoleName, opt => opt.MapFrom(src => src.RoleCodeNavigation.Name));

            CreateMap<DTO.Models.Employee, Employee>();

            
            CreateMap<EmployeeRole, DTO.Models.EmployeeRole>().ReverseMap();
        }
    }

    public static class MapperExtention
    {
        private static IMapper _mapper;

        public static IServiceCollection RegisterMapper(this IServiceCollection services)
        {
            var sbp = services.BuildServiceProvider();
            _mapper = sbp.GetService<IMapper>();
            return services;
        }

        public static T Map<T>(this object source)
        {
            return _mapper.Map<T>(source);
        }

        public static IList<TOut> MapList<TOut>(this object listSource)
        {
            return _mapper.Map<IList<TOut>>(listSource);
        }
    }
}

