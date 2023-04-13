using AngularMovieAPI2.Models.Movie;
using AngularMovieAPI2.ModelsDto.MovieDto;

namespace AngularMovieAPI2.Services.MovieService
{
    public interface IMovieService
    {
        public Task<IEnumerable<MovieWithGenreName>> GetMovies();
        public Task<MovieWithGenreName> GetMoviesByID(int MovieID);
        public Task<Movie> CreateMovie(CreateMovieModel Movies);
        public Task<Movie> UpdateMovie(UpdateMovieModel updateMovie);
        public Task<IEnumerable<MovieWithGenreName>> GetGenresMovie(int GenreID);
        public Task<Movie> DeleteMovie(int MovieID);
    }
}
