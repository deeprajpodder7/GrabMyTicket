using AngularMovieAPI2.Models.Bookings;
using AngularMovieAPI2.ModelsDto.BookingDto;

namespace AngularMovieAPI2.Repository.BookingRepo
{
    public interface IBookingRepository
    {
        public Task<IEnumerable<Booking>> getBookings();
        public Task<Booking> GetBookingByID(int BookingID);
        public Task<IEnumerable<Booking>> GetBookingByuserID(int userID);
        public Task<Booking> CreateBooking(BookingDto createBooking);
        public Task<Booking> CreateBookingWithData(Booking booking);
        public Task<Booking> UpdateBooking(BookingDto updateBooking, int BookingID);
        public Task<Booking> DeleteBooking(int BookingID);
    }
}
