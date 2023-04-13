using AngularMovieAPI2.Models.Cinema;
using AngularMovieAPI2.ModelsDto.CinemaDto;

namespace AngularMovieAPI2.Services.CinemaAddressService
{
    public interface ICinemaAddressService
    {
        public Task<IEnumerable<CinemaAddress>> GetCinemaAddresses();
        public Task<CinemaAddress> GetCinemaAddressByID(int AddressID);
        public Task<CinemaAddress> CreateCinemaAddress(AddressDto createAddress);
        public Task<CinemaAddress> UpdateCinemaAddress(AddressDto updateAddress, int AddressID);
        public Task<CinemaAddress> DeleteCinemaAddress(int AddressID);
    }
}
