using AngularMovieAPI2.Models.Cinema;
using AngularMovieAPI2.ModelsDto.CinemaDto;

namespace AngularMovieAPI2.Services.CinemaServices
{
    public interface ICinemaService
    {
        public Task<IEnumerable<Cinema>> GetCinemas();
        public Task<Cinema> GetCinemaByID(int CinemaID);
        public Task<Cinema> CreateCinema(CinemaModelDto CreateCinema);
        public Task<Cinema> UpdateCinema(CinemaModelDto UpdateCinema, int CinemaID);
        public Task<Cinema> DeleteCinema(int CinemaID);
    }
}
