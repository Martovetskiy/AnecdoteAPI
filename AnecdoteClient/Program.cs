using AnecdoteClient;
using AutoMapper;

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();

var anecdoteClient = new AnecdoteClientImpl("http://localhost:9999", mapper);
var anecdotes = await anecdoteClient.GetAllAnecdotesAsync();

if (anecdotes != null)
{
    foreach (var anecdote in anecdotes)
    {
        Console.WriteLine(anecdote);
    }
}