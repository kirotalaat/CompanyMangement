using AutoMapper;
using DataAcessLayer.Models;
using PresentationLayer.ViewModel;

namespace PresentationLayer.MappedProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeViewModel, Employee>().ReverseMap();
        }
    }
}
