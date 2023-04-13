using AngularMovieAPI2.Models.Movie;
using AngularMovieAPI2.ModelsDto.GenreDto;

namespace AngularMovieAPI2.Repository.GenreRepo
{
    public interface IGenreRepository
    {
        public Task<IEnumerable<GenreDto>> GetGenres();
        public Task<GenreDto> GetGenreByID(int GenreID);
        public Task<Genre> CreateGenre(CreateGenre createGenre);
        public Task<Genre> UpdateGenre(GenreDto updateGenre, int GenreID);
        public Task<Genre> DeleteGenre(int GenreID);
    }
}
