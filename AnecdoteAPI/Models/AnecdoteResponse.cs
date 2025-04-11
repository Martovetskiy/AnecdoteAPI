namespace AnecdoteAPI.Models
{
    public class AnecdoteResponse
    {
        public List<Anecdote> Anecdotes { get; set; } = new List<Anecdote>();
    }
}
