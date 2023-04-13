using AngularMovieAPI2.Environment;
using AngularMovieAPI2.Helper;
using AngularMovieAPI2.Models.Cinema;
using AngularMovieAPI2.ModelsDto.CinemaDto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AngularMovieAPI2.Repository.CinemaRepo
{
    public class CinemaHallRepository:ICinemaHallRepository
    {
        private readonly ApplicationDbContext context;
        private IMapper mapper;
        public CinemaHallRepository(ApplicationDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task<CinemaHall> CreateCinemaHall(CinemaHallDto CreateCinemaHall)
        {
            var createModel = mapper.Map<CinemaHall>(CreateCinemaHall);
            await context.CinemaHalls.AddAsync(createModel);
            await context.SaveChangesAsync();
            return createModel;
        }

        public async Task<CinemaHall> DeleteCinemaHall(int CinemaHallID)
        {
            var deleteCinemaHall = await context.CinemaHalls.Where(c => c.CinemaHallID == CinemaHallID).SingleOrDefaultAsync();
            if (deleteCinemaHall != null)
            {
                context.CinemaHalls.Remove(deleteCinemaHall);
                await context.SaveChangesAsync();


            }
            return deleteCinemaHall;
        }

        public async Task<CinemaHall> GetCinemaHallByID(int CinemaHallID)
        {
            return await context.CinemaHalls.Include(ch => ch.CinemaSeats).Where(c => c.CinemaHallID == CinemaHallID).FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<CinemaHall>> GetCinemaHalls()
        {
            return await context.CinemaHalls.Include(ch => ch.CinemaSeats).ToListAsync();

        }

        public async Task<CinemaHall> UpdateCinemaHall(CinemaHallDto UpdateCinemaHall, int CinemaHallID)
        {
            var updatedCinemaHall = mapper.Map<CinemaHall>(UpdateCinemaHall);
            var CinemaHall = await context.CinemaHalls.FindAsync(CinemaHallID);
            if (CinemaHall == null)
            {
                throw new AppException("Genre not found");

            }
            if (!string.IsNullOrWhiteSpace(updatedCinemaHall.Name))
            {
                CinemaHall.Name = updatedCinemaHall.Name;
            }
            if (!string.IsNullOrWhiteSpace(updatedCinemaHall.TotalSeats.ToString()))
            {
                CinemaHall.TotalSeats = updatedCinemaHall.TotalSeats;
            }
            if (!string.IsNullOrWhiteSpace(updatedCinemaHall.CinemaID.ToString()))
            {
                CinemaHall.CinemaID = updatedCinemaHall.CinemaID;
            }
            context.CinemaHalls.Update(CinemaHall);
            await context.SaveChangesAsync();

            return CinemaHall;

        }
    }
}
