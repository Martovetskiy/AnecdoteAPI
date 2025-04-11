using AnecdoteAPI.Interfaces;
using AutoMapper;
using Grpc.Core;

namespace AnecdoteAPI.Services
{
    public class AnecdoteServiceImpl : AnecdoteService.AnecdoteServiceBase
    {
        private readonly IAnecdoteRepository _repository;
        private readonly IMapper _mapper;

        public AnecdoteServiceImpl(IAnecdoteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public override async Task<GetAllResponse> GetAllAnecdotes(GetAllRequest request, ServerCallContext context)
        {
            var response = await _repository.GetAllAnecdotesAsync();
            var grpcResponse = new GetAllResponse();

            grpcResponse.Anecdotes.AddRange(response.Anecdotes.Select(anecdote => _mapper.Map<GrpcAnecdoteModel>(anecdote)));
            return grpcResponse;
        }
    }
}
