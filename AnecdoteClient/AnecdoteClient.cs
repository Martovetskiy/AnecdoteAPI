using Grpc.Net.Client;
using AnecdoteAPI;
using AutoMapper;

public class AnecdoteClientImpl
{
    private readonly string _address;
    private readonly IMapper _mapper;

    public AnecdoteClientImpl(string address, IMapper mapper)
    {
        _address = address;
        _mapper = mapper;
    }

    public async Task<List<string>> GetAllAnecdotesAsync()
    {
        var channel = GrpcChannel.ForAddress(_address);
        var client = new AnecdoteService.AnecdoteServiceClient(channel);
        var request = new GetAllRequest();

        try
        {
            var reply = await client.GetAllAnecdotesAsync(request);
            return reply.Anecdotes.Select(a => a.Content).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }
}
