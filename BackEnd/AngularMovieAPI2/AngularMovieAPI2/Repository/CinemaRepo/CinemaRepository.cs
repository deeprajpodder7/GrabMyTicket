using AngularMovieAPI2.Environment;
using AngularMovieAPI2.Helper;
using AngularMovieAPI2.Models.Cinema;
using AngularMovieAPI2.ModelsDto.CinemaDto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AngularMovieAPI2.Repository.CinemaRepo
{
    public class CinemaRepository : ICinemaRepository
    {
        private readonly ApplicationDbContext context;
        private IMapper mapper;
        public CinemaRepository(ApplicationDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }
        public async Task<Cinema> CreateCinema(CinemaModelDto CreateCinema)
        {
            var createModel = mapper.Map<Cinema>(CreateCinema);
            var createAddress = mapper.Map<CinemaAddress>(CreateCinema.CinemaAddress);
            createModel.CinemaAddresses = createAddress;
            await context.Cinemas.AddAsync(createModel);
            await context.SaveChangesAsync();
            return createModel;
        }

        public async Task<Cinema> DeleteCinema(int CinemaID)
        {
            var deleteCinema = await context.Cinemas.Include(a => a.CinemaAddresses).Where(c => c.CinemaID == CinemaID).SingleOrDefaultAsync();
            var deleteAddress = await context.CinemaAddresses.Where(c => c.CinemaAdressID == deleteCinema.CinemaAddressID).SingleOrDefaultAsync();
            if (deleteCinema != null)
            {
                context.Cinemas.Remove(deleteCinema);
                context.CinemaAddresses.Remove(deleteAddress);

                await context.SaveChangesAsync();
            }
            return deleteCinema;
        }

        public async Task<Cinema> GetCinemaByID(int CinemaID)
        {
            return await context.Cinemas.Include(ch => ch.CinemaHalls).Include(ca => ca.CinemaAddresses).Where(c => c.CinemaID == CinemaID).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Cinema>> GetCinemas()
        {
            return await context.Cinemas.Include(ch => ch.CinemaHalls).Include(ca => ca.CinemaAddresses).ToListAsync();
        }

        public async Task<Cinema> UpdateCinema(CinemaModelDto UpdateCinema, int CinemaID)
        {
            var updatedCinema = mapper.Map<Cinema>(UpdateCinema);
            var updatedAddress = mapper.Map<CinemaAddress>(UpdateCinema.CinemaAddress);
            var Cinema = await context.Cinemas.FindAsync(CinemaID);
            var Address = await context.CinemaAddresses.FindAsync(Cinema.CinemaAddressID);
            if (Cinema == null)
            {
                throw new AppException("Genre not found");

            }
            if (!string.IsNullOrWhiteSpace(updatedCinema.Name))
            {
                Cinema.Name = updatedCinema.Name;
            }
            if (!string.IsNullOrWhiteSpace(updatedCinema.TotalCinemaHalls.ToString()))
            {
                Cinema.TotalCinemaHalls = context.CinemaHalls.Where(ch => ch.CinemaID == CinemaID).ToList().Count();
            }

            if (!string.IsNullOrWhiteSpace(updatedAddress.Address1))
            {
                Address.Address1 = updatedAddress.Address1;
            }
            if (!string.IsNullOrWhiteSpace(updatedAddress.Address2))
            {
                Address.Address2 = updatedAddress.Address2;
            }
            if (!string.IsNullOrWhiteSpace(updatedAddress.City))
            {
                Address.City = updatedAddress.City;
            }
            if (!string.IsNullOrWhiteSpace(updatedAddress.Country))
            {
                Address.Country = updatedAddress.Country;
            }
            if (!string.IsNullOrWhiteSpace(updatedAddress.ZipCode))
            {
                Address.ZipCode = updatedAddress.ZipCode;
            }
            context.Cinemas.Update(Cinema);
            context.CinemaAddresses.Update(Address);
            await context.SaveChangesAsync();

            return Cinema;

        }
    }
}
