using MinimalApi_JWT.Models;

namespace MinimalApi_JWT.Services
{
    public interface IMovieService
    {
        public Movie Create(Movie movie);
        public Movie Get(int id);
        public List<Movie> GetAll();
        public Movie Update(Movie movie);
        public bool Delete(int id);
    }
}
