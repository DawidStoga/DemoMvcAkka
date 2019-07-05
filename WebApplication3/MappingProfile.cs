using ApiDemo.Models;
using AutoMapper;

namespace ApiDemo
{
    public  class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreatePerson, Person>();
        }
    }
}