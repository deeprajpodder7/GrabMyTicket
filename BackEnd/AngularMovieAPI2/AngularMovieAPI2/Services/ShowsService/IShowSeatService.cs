using AngularMovieAPI2.Models.Show;
using AngularMovieAPI2.ModelsDto.ShowDto;

namespace AngularMovieAPI2.Services.ShowsService
{
    public interface IShowSeatService
    {
        public Task<IEnumerable<ShowSeat>> getShowSeats();
        public Task<ShowSeat> GetShowSeatByID(int ShowSeatID);
        public Task<IEnumerable<ShowSeat>> getShowSeatsByShowID(int ShowID);

        public Task<ShowSeat> CreateShowSeat(ShowSeatDto createShowSeat);

        public Task<ShowSeat> UpdateShowSeat(ShowSeatDto updateShowSeat, int ShowSeatID);
        public Task<ShowSeat> DeleteShowSeat(int ShowSeatID);
    }
}
