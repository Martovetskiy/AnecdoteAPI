using Grpc.Core;
using AutoMapper;
using AnecdoteAPI;

namespace AnecdoteClient
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GrpcAnecdoteModel, string>().ConvertUsing(a => a.Content);
        }
    }
}
