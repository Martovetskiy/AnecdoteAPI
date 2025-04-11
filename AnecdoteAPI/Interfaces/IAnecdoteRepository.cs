using AnecdoteAPI.Models;

namespace AnecdoteAPI.Interfaces
{
    public interface IAnecdoteRepository
    {
        Task<AnecdoteResponse> GetAllAnecdotesAsync();
    }

}
