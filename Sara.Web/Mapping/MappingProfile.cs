using AutoMapper;
using ClassLibrary1.Entities;
using saraproject.Models;

namespace saraproject.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Object, ObjectDto>();
        }
    }
}