using AngularMovieAPI2.Models.Cinema;
using AngularMovieAPI2.ModelsDto.CinemaDto;

namespace AngularMovieAPI2.Services.CinemaServices
{
    public interface ICinemaSeatService
    {
        public Task<IEnumerable<CinemaSeat>> GetCinemaSeats();
        public Task<CinemaSeat> GetCinemaSeatByID(int CinemaSeatID);
        public Task<CinemaSeat> CreateCinemaSeat(CinemaSeatModelDto CreateCinemaSeat);
        public Task<CinemaSeat> UpdateCinemaSeat(CinemaSeatModelDto UpdateCinemaSeat, int CinemaSeatID);
        public Task<CinemaSeat> DeleteCinemaSeat(int CinemaSeatID);
    }
}
