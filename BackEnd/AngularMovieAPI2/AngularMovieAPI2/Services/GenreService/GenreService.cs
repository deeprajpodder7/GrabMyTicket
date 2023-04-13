using AngularMovieAPI2.Models.Movie;
using AngularMovieAPI2.ModelsDto.GenreDto;
using AngularMovieAPI2.Repository.GenreRepo;

namespace AngularMovieAPI2.Services.GenreService
{
    public class GenreService : IGenreService
    {
        private IGenreRepository genreRepo;
        public GenreService(IGenreRepository _context)
        {
            genreRepo = _context;
        }
        public async Task<IEnumerable<GenreDto>> GetGenres() => await genreRepo.GetGenres();
        public async Task<GenreDto> GetGenreByID(int GenreID) => await genreRepo.GetGenreByID(GenreID);
        public async Task<Genre> CreateGenre(CreateGenre createGenre) => await genreRepo.CreateGenre(createGenre);
        public async Task<Genre> UpdateGenre(GenreDto updateGenre, int GenreID) => await genreRepo.UpdateGenre(updateGenre, GenreID);
        public async Task<Genre> DeleteGenre(int GenreID) => await genreRepo.DeleteGenre(GenreID);




    }
}
