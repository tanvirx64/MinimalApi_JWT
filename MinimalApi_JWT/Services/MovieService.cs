using MinimalApi_JWT.Models;
using MinimalApi_JWT.Repositories;

namespace MinimalApi_JWT.Services
{
    public class MovieService : IMovieService
    {
        public Movie Create(Movie movie)
        {
            movie.Id = MovieRepository.movies.Count + 1;
            MovieRepository.movies.Add(movie);
            return movie;
        }
        public Movie Get(int id)
        {
            var movie = MovieRepository.movies.FirstOrDefault(x => x.Id == id);

            if (movie is null) return null;

            return movie;
        }

        public List<Movie> GetAll()
        {
            return MovieRepository.movies;
        }

        public Movie Update(Movie newMovie)
        {
            var oldMovie = MovieRepository.movies.FirstOrDefault(x => x.Id == newMovie.Id);
            if (oldMovie is null) return null;
            
            oldMovie.Title = newMovie.Title;
            oldMovie.Description = newMovie.Description;
            oldMovie.Rating = newMovie.Rating;

            return newMovie;
        }

        public bool Delete(int id)
        {
            var movie = MovieRepository.movies.FirstOrDefault(x => x.Id == id);
            if (movie is null) return false;

            MovieRepository.movies.Remove(movie);

            return true;
        }

       
    }
}
