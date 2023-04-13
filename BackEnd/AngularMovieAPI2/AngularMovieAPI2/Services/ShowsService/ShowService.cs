using AngularMovieAPI2.Models.Show;
using AngularMovieAPI2.ModelsDto.ShowDto;
using AngularMovieAPI2.Repository.ShowRepo;
using AutoMapper;

namespace AngularMovieAPI2.Services.ShowsService
{
    public class ShowService : IShowService
    {
        private readonly IShowRepository showRepo;
        private IMapper mapper;

        public ShowService(IShowRepository _showRepo, IMapper _mapper)
        {
            showRepo = _showRepo;
            mapper = _mapper;
        }

        public async Task<Show> CreateShow(ShowDetailsDto CreateShow) => await showRepo.CreateShow(CreateShow);

        public async Task<Show> UpdateShow(ShowDetailsDto UpdateShow, int ShowID) => await showRepo.UpdateShow(UpdateShow, ShowID);

        public async Task<IEnumerable<Show>> GetShows() => await showRepo.GetShows();

        public async Task<Show> GetShowByID(int CinemaID) => await showRepo.GetShowByID(CinemaID);


        public async Task<Show> DeleteShow(int ShowID) => await showRepo.DeleteShow(ShowID);

        public async Task<IEnumerable<Show>> GetShowByMovieID(int MovieID) => await showRepo.GetShowByMovieID(MovieID);
    }
}
