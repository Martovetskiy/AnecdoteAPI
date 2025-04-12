using AnecdoteAPI.AutoMapperProfiles;
using AnecdoteAPI.Interfaces;
using AnecdoteAPI.Repositories;
using AnecdoteAPI.Services;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IAnecdoteRepository>(new AnecdoteRepository());


var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton<IMapper>(mapper);



builder.Services.AddGrpc();

var app = builder.Build();

app.MapGrpcService<GreeterService>();

app.MapGrpcService<AnecdoteServiceImpl>();
app.MapGet("/protos/anecdote.proto", async context =>
{
    await context.Response.WriteAsync(File.ReadAllText("Protos/anecdote.proto"));
});

app.Run();
