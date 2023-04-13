using AngularMovieAPI2.Models.Bookings;
using AngularMovieAPI2.ModelsDto.BookingDto;
using AngularMovieAPI2.Repository.BookingRepo;

namespace AngularMovieAPI2.Services.BookingsService
{
    public class BookingService : IBookingService
    {
        public IBookingRepository bookingRepo;
        public BookingService(IBookingRepository _bookingRepo)
        {
            bookingRepo = _bookingRepo;
        }



        public async Task<IEnumerable<Booking>> getBookings() => await bookingRepo.getBookings();
        public async Task<Booking> GetBookingByID(int BookingID) => await bookingRepo.GetBookingByID(BookingID);
        public async Task<Booking> CreateBookingWithData(Booking booking) => await bookingRepo.CreateBookingWithData(booking);
        public async Task<IEnumerable<Booking>> GetBookingByuserID(int userID) => await bookingRepo.GetBookingByuserID(userID);

        public async Task<Booking> CreateBooking(BookingDto createBooking) => await bookingRepo.CreateBooking(createBooking);
        public async Task<Booking> UpdateBooking(BookingDto updateBooking, int BookingID) => await bookingRepo.UpdateBooking(updateBooking, BookingID);
        public async Task<Booking> DeleteBooking(int BookingID) => await bookingRepo.DeleteBooking(BookingID);

    }
}
