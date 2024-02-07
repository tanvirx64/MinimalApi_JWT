using MinimalApi_JWT.Models;

namespace MinimalApi_JWT.Repositories
{
    public class MovieRepository
    {
        public static List<Movie> movies = new List<Movie>() 
        {
            new() { Id = 1, Title = "Inception", Description = "Mind-bending thriller", Rating = 4.5 },
            new() { Id = 2, Title = "The Shawshank Redemption", Description = "Prison drama", Rating = 4.8 },
            new() { Id = 3, Title = "The Dark Knight", Description = "Superhero action", Rating = 4.7 },
            new() { Id = 4, Title = "Pulp Fiction", Description = "Quentin Tarantino classic", Rating = 4.6 },
            new() { Id = 5, Title = "Forrest Gump", Description = "Heartwarming drama", Rating = 4.4 },
            new() { Id = 5, Title = "Journey To The Center of the Earth", Description = "Adventure", Rating = 4.5 }
        };
    }
}
