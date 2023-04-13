using AngularMovieAPI2.Models.Cinema;
using AngularMovieAPI2.ModelsDto.CinemaDto;

namespace AngularMovieAPI2.Repository.CinemaRepo
{
    public interface ICinemaHallRepository
    {

        public Task<IEnumerable<CinemaHall>> GetCinemaHalls();
        public Task<CinemaHall> GetCinemaHallByID(int CinemaHallID);
        public Task<CinemaHall> CreateCinemaHall(CinemaHallDto CreateCinemaHall);
        public Task<CinemaHall> UpdateCinemaHall(CinemaHallDto UpdateCinemaHall, int CinemaHallID);
        public Task<CinemaHall> DeleteCinemaHall(int CinemaHallID);
    }
}
