using AngularMovieAPI2.Models.Show;
using AngularMovieAPI2.ModelsDto.ShowDto;

namespace AngularMovieAPI2.Repository.ShowRepo
{
    public interface IShowRepository
    {
        public Task<IEnumerable<Show>> GetShows();
        public Task<Show> GetShowByID(int CinemaID);
        public Task<IEnumerable<Show>> GetShowByMovieID(int MovieID);

        public Task<Show> CreateShow(ShowDetailsDto CreateShow);
        public Task<Show> UpdateShow(ShowDetailsDto UpdateShow, int ShowID);
        public Task<Show> DeleteShow(int ShowID);
    }
}
