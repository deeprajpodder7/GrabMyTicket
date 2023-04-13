using AngularMovieAPI2.Models.Movie;
using AngularMovieAPI2.ModelsDto.MovieDto;

namespace AngularMovieAPI2.Repository.MovieRepo
{
    public interface IMovieRepository
    {
        public Task<IEnumerable<MovieWithGenreName>> GetMovies();
        public Task<MovieWithGenreName> GetMoviesByID(int MovieID);

        public Task<Movie> CreateMovie(CreateMovieModel CreateMovie);
        public Task<Movie> UpdateMovie(UpdateMovieModel CreateMovie);

        public Task<IEnumerable<MovieWithGenreName>> GetGenresMovie(int GenreID);
        public Task<Movie> DeleteMovie(int MovieID);
    }
}
