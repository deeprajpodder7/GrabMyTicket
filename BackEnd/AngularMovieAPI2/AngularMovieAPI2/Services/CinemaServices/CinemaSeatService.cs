using AngularMovieAPI2.Models.Cinema;
using AngularMovieAPI2.ModelsDto.CinemaDto;
using AngularMovieAPI2.Repository.CinemaRepo;

namespace AngularMovieAPI2.Services.CinemaServices
{
    public class CinemaSeatService : ICinemaSeatService
    {
        private readonly ICinemaSeatRepository CinemaSeatRepo;
        public CinemaSeatService(ICinemaSeatRepository _CinemaSeatRepo)
        {
            CinemaSeatRepo = _CinemaSeatRepo;
        }

        public async Task<CinemaSeat> CreateCinemaSeat(CinemaSeatModelDto CreateCinemaSeat) => await CinemaSeatRepo.CreateCinemaSeat(CreateCinemaSeat);

        public async Task<CinemaSeat> DeleteCinemaSeat(int CinemaSeatID) => await CinemaSeatRepo.DeleteCinemaSeat(CinemaSeatID);

        public async Task<CinemaSeat> GetCinemaSeatByID(int CinemaSeatID) => await CinemaSeatRepo.GetCinemaSeatByID(CinemaSeatID);

        public async Task<IEnumerable<CinemaSeat>> GetCinemaSeats() => await CinemaSeatRepo.GetCinemaSeats();

        public async Task<CinemaSeat> UpdateCinemaSeat(CinemaSeatModelDto UpdateCinemaSeat, int CinemaSeatID) => await CinemaSeatRepo.UpdateCinemaSeat(UpdateCinemaSeat, CinemaSeatID);
    }
}
