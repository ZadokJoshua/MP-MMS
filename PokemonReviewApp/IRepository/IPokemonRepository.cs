using PokemonReviewApp.Models;

namespace PokemonReviewApp.IRepository
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
    }
}
