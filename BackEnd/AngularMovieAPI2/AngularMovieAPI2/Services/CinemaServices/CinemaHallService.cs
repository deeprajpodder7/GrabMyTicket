using AngularMovieAPI2.Models.Cinema;
using AngularMovieAPI2.ModelsDto.CinemaDto;
using AngularMovieAPI2.Repository.CinemaRepo;

namespace AngularMovieAPI2.Services.CinemaServices
{
    public class CinemaHallService : ICinemaHallService
    {
        private readonly ICinemaHallRepository cinemaHallRepo;
        public CinemaHallService(ICinemaHallRepository _cinemaHallRepo)
        {
            cinemaHallRepo = _cinemaHallRepo;
        }

        public async Task<CinemaHall> CreateCinemaHall(CinemaHallDto CreateCinemaHall) => await cinemaHallRepo.CreateCinemaHall(CreateCinemaHall);

        public async Task<CinemaHall> DeleteCinemaHall(int CinemaHallID) => await cinemaHallRepo.DeleteCinemaHall(CinemaHallID);

        public async Task<CinemaHall> GetCinemaHallByID(int CinemaHallID) => await cinemaHallRepo.GetCinemaHallByID(CinemaHallID);

        public async Task<IEnumerable<CinemaHall>> GetCinemaHalls() => await cinemaHallRepo.GetCinemaHalls();


        public async Task<CinemaHall> UpdateCinemaHall(CinemaHallDto UpdateCinemaHall, int CinemaHallID) => await cinemaHallRepo.UpdateCinemaHall(UpdateCinemaHall, CinemaHallID);

    }
}
