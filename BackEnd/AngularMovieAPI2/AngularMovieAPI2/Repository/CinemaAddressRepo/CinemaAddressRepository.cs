using AngularMovieAPI2.Environment;
using AngularMovieAPI2.Helper;
using AngularMovieAPI2.Models.Cinema;
using AngularMovieAPI2.ModelsDto.CinemaDto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AngularMovieAPI2.Repository.CinemaAddressRepo
{
    public class CinemaAddressRepository : ICinemaAddressRepository
    {
        private readonly ApplicationDbContext context;
        private IMapper mapper;
        public CinemaAddressRepository(ApplicationDbContext _context, IMapper _mapper) // Dependency Injection
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task<CinemaAddress> CreateCinemaAddress(AddressDto createAddress)
        {
            var model = mapper.Map<CinemaAddress>(createAddress);
            await context.CinemaAddresses.AddAsync(model);
            await context.SaveChangesAsync();
            return model;

        }

        public async Task<CinemaAddress> DeleteCinemaAddress(int AddressID)
        {
            var deleteAddress = await context.CinemaAddresses.FindAsync(AddressID);
            if (deleteAddress != null)
            {
                context.CinemaAddresses.Remove(deleteAddress);
                await context.SaveChangesAsync();
            }
            return deleteAddress;
        }

        public async Task<CinemaAddress> GetCinemaAddressByID(int AddressID)
        {
            return await context.CinemaAddresses.Include(c => c.Cinema).Where(g => g.CinemaAdressID == AddressID).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CinemaAddress>> GetCinemaAddresses()
        {
            return await context.CinemaAddresses.Include(c => c.Cinema).ToListAsync();

        }

        public async Task<CinemaAddress> UpdateCinemaAddress(AddressDto model, int AddressID)
        {
            var updateAddress = mapper.Map<CinemaAddress>(model);

            var address = await context.CinemaAddresses.FindAsync(AddressID);
            if (address == null)
            {
                throw new AppException("Genre not found");

            }

            if (!string.IsNullOrWhiteSpace(updateAddress.Address1))
            {
                address.Address1 = updateAddress.Address1;
            }
            if (!string.IsNullOrWhiteSpace(updateAddress.Address2))
            {
                address.Address2 = updateAddress.Address2;
            }
            if (!string.IsNullOrWhiteSpace(updateAddress.ZipCode))
            {
                address.ZipCode = updateAddress.ZipCode;
            }
            if (!string.IsNullOrWhiteSpace(updateAddress.City))
            {
                address.City = updateAddress.City;
            }
            if (!string.IsNullOrWhiteSpace(updateAddress.Country))
            {
                address.Country = updateAddress.Country;
            }
            context.CinemaAddresses.Update(address);
            await context.SaveChangesAsync();
            return address;

        }
    }
}
