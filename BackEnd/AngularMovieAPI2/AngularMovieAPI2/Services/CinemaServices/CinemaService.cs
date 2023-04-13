using AngularMovieAPI2.Models.Cinema;
using AngularMovieAPI2.ModelsDto.CinemaDto;
using AngularMovieAPI2.Repository.CinemaRepo;

namespace AngularMovieAPI2.Services.CinemaServices
{
    public class CinemaService : ICinemaService
    {
        private readonly ICinemaRepository cinemaRepo;
        public CinemaService(ICinemaRepository _cinemaRepo)
        {
            cinemaRepo = _cinemaRepo;
        }

        public async Task<Cinema> CreateCinema(CinemaModelDto CreateCinema) => await cinemaRepo.CreateCinema(CreateCinema);

        public async Task<Cinema> DeleteCinema(int CinemaID) => await cinemaRepo.DeleteCinema(CinemaID);

        public async Task<Cinema> GetCinemaByID(int CinemaID) => await cinemaRepo.GetCinemaByID(CinemaID);

        public async Task<IEnumerable<Cinema>> GetCinemas() => await cinemaRepo.GetCinemas();

        public async Task<Cinema> UpdateCinema(CinemaModelDto UpdateCinema, int CinemaID) => await cinemaRepo.UpdateCinema(UpdateCinema, CinemaID);
    }
}
