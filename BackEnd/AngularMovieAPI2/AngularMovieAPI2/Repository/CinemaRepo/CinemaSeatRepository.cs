using AngularMovieAPI2.Environment;
using AngularMovieAPI2.Helper;
using AngularMovieAPI2.Models.Cinema;
using AngularMovieAPI2.ModelsDto.CinemaDto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AngularMovieAPI2.Repository.CinemaRepo
{
    public class CinemaSeatRepository : ICinemaSeatRepository
    {
        private readonly ApplicationDbContext context;
        private IMapper mapper;
        public CinemaSeatRepository(ApplicationDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }
        public async Task<CinemaSeat> CreateCinemaSeat(CinemaSeatModelDto CreateCinemaSeat)
        {
            var createModel = mapper.Map<CinemaSeat>(CreateCinemaSeat);
            await context.CinemaSeats.AddAsync(createModel);
            await context.SaveChangesAsync();
            return createModel;
        }

        public async Task<CinemaSeat> DeleteCinemaSeat(int CinemaSeatID)
        {
            var deleteCinemaSeat = await context.CinemaSeats.Where(c => c.CinemaSeatID == CinemaSeatID).SingleOrDefaultAsync();
            if (deleteCinemaSeat != null)
            {
                context.CinemaSeats.Remove(deleteCinemaSeat);

                await context.SaveChangesAsync();
            }
            return deleteCinemaSeat;
        }

        public async Task<CinemaSeat> GetCinemaSeatByID(int CinemaSeatID)
        {
            return await context.CinemaSeats.Where(c => c.CinemaSeatID == CinemaSeatID).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CinemaSeat>> GetCinemaSeats()
        {
            return await context.CinemaSeats.ToListAsync();
        }

        public async Task<CinemaSeat> UpdateCinemaSeat(CinemaSeatModelDto UpdateCinemaSeat, int CinemaSeatID)
        {
            var updatedCinemaSeat = mapper.Map<CinemaSeat>(UpdateCinemaSeat);
            var CinemaSeat = await context.CinemaSeats.FindAsync(CinemaSeatID);
            if (CinemaSeat == null)
            {
                throw new AppException("Genre not found");

            }
            if (!string.IsNullOrWhiteSpace(updatedCinemaSeat.SeatNumber.ToString()))
            {
                CinemaSeat.SeatNumber = updatedCinemaSeat.SeatNumber;
            }
            if (!string.IsNullOrWhiteSpace(updatedCinemaSeat.type.ToString()))
            {
                CinemaSeat.type = updatedCinemaSeat.type;
            }
            if (!string.IsNullOrWhiteSpace(updatedCinemaSeat.CinemaHallID.ToString()))
            {
                CinemaSeat.CinemaHallID = updatedCinemaSeat.CinemaHallID;
            }


            context.CinemaSeats.Update(CinemaSeat);
            await context.SaveChangesAsync();

            return CinemaSeat;

        }
    }
}
