using AngularMovieAPI2.Models.Show;
using AngularMovieAPI2.ModelsDto.ShowDto;
using AngularMovieAPI2.Repository.ShowRepo;

namespace AngularMovieAPI2.Services.ShowsService
{
    public class ShowSeatService : IShowSeatService
    {
        public IShowSeatRepository ShowSeatRepo;
        public ShowSeatService(IShowSeatRepository _ShowSeatRepo)
        {
            ShowSeatRepo = _ShowSeatRepo;
        }

        public async Task<IEnumerable<ShowSeat>> getShowSeats() => await ShowSeatRepo.getShowSeats();
        public async Task<ShowSeat> GetShowSeatByID(int ShowSeatID) => await ShowSeatRepo.GetShowSeatByID(ShowSeatID);
        public async Task<IEnumerable<ShowSeat>> getShowSeatsByShowID(int ShowID) => await ShowSeatRepo.getShowSeatsByShowID(ShowID);

        public async Task<ShowSeat> CreateShowSeat(ShowSeatDto createShowSeat) => await ShowSeatRepo.CreateShowSeat(createShowSeat);
        public async Task<ShowSeat> UpdateShowSeat(ShowSeatDto updateShowSeat, int ShowSeatID) => await ShowSeatRepo.UpdateShowSeat(updateShowSeat, ShowSeatID);
        public async Task<ShowSeat> DeleteShowSeat(int ShowSeatID) => await ShowSeatRepo.DeleteShowSeat(ShowSeatID);
    }
}
