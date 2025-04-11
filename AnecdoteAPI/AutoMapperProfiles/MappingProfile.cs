using AnecdoteAPI.Models;
using AutoMapper;

namespace AnecdoteAPI.AutoMapperProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Anecdote, GrpcAnecdoteModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content));
        }
    }
}
