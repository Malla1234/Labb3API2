using Labb3API2.Models.DTO;
using Labb3API2.Models;
using AutoMapper;

namespace Labb3API2
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<Person, PersonCreateDto>().ReverseMap();

            CreateMap<Interest, InterestDto>().ReverseMap();
            CreateMap<Interest, InterestCreateDto>().ReverseMap();

            CreateMap<Link, LinkDto>().ReverseMap();
            CreateMap<Link, LinkCreateDto>().ReverseMap();
        }
    }
}
