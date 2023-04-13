using AngularMovieAPI2.Environment;
using AngularMovieAPI2.Helper;
using AngularMovieAPI2.Models.Show;
using AngularMovieAPI2.ModelsDto.ShowDto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AngularMovieAPI2.Repository.ShowRepo
{
    public class ShowRepository : IShowRepository
    {
        private readonly ApplicationDbContext context;
        private IMapper mapper;
        public ShowRepository(ApplicationDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task<Show> CreateShow(ShowDetailsDto model)
        {
            var createModel = mapper.Map<Show>(model);
            createModel.CinemaHall = await context.CinemaHalls.FindAsync(model.CinemaHallID);
            createModel.Movie = await context.Movies.FindAsync(model.MovieID);

            await context.Shows.AddAsync(createModel);
            await context.SaveChangesAsync();
            return createModel;
        }

        public async Task<Show> DeleteShow(int ShowID)
        {
            var deleteShow = await context.Shows.FindAsync(ShowID);
            context.Shows.Remove(deleteShow);
            await context.SaveChangesAsync();
            return deleteShow;
        }

        public async Task<Show> GetShowByID(int CinemaID)
        {
            return await context.Shows.FindAsync(CinemaID);

        }
        public async Task<IEnumerable<Show>> GetShowByMovieID(int MovieID)
        {

            return await context.Shows.Where(s => s.MovieID == MovieID).ToListAsync();
        }

        public async Task<IEnumerable<Show>> GetShows()
        {
            return await context.Shows.ToListAsync();
        }

        public async Task<Show> UpdateShow(ShowDetailsDto UpdateShow, int ShowID)
        {
            var updatedShow = mapper.Map<Show>(UpdateShow);
            var Show = await context.Shows.FindAsync(ShowID);

            if (Show == null)
            {
                throw new AppException("Show not found");

            }
            if (!string.IsNullOrWhiteSpace(updatedShow.Date.ToString()))
            {
                Show.Date = updatedShow.Date;
            }
            if (!string.IsNullOrWhiteSpace(updatedShow.StartTime.ToString()))
            {
                Show.StartTime = updatedShow.StartTime;
            }
            if (!string.IsNullOrWhiteSpace(updatedShow.EndTime.ToString()))
            {
                Show.EndTime = updatedShow.EndTime;
            }
            if (!string.IsNullOrWhiteSpace(updatedShow.MovieID.ToString()))
            {
                Show.Movie = await context.Movies.Where(m => m.MovieID == updatedShow.MovieID).SingleOrDefaultAsync();
            }
            if (!string.IsNullOrWhiteSpace(updatedShow.CinemaHallID.ToString()))
            {
                Show.CinemaHall = await context.CinemaHalls.Where(ch => ch.CinemaHallID == updatedShow.CinemaHallID).SingleOrDefaultAsync();
            }

            context.Shows.Update(Show);
            await context.SaveChangesAsync();
            return Show;
        }
    }
}
