using AngularMovieAPI2.Models.Bookings;
using AngularMovieAPI2.ModelsDto.BookingDto;

namespace AngularMovieAPI2.Services.BookingsService
{
    public interface IBookingService
    {
        public Task<IEnumerable<Booking>> getBookings();
        public Task<Booking> GetBookingByID(int BookingID);
        public Task<Booking> CreateBooking(BookingDto createBooking);
        public Task<Booking> CreateBookingWithData(Booking booking);
        public Task<IEnumerable<Booking>> GetBookingByuserID(int userID);

        public Task<Booking> UpdateBooking(BookingDto updateBooking, int BookingID);
        public Task<Booking> DeleteBooking(int BookingID);
    }
}
