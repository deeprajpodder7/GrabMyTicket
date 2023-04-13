using AngularMovieAPI2.Models.Bookings;
using AngularMovieAPI2.Repository.BookingRepo;
using AngularMovieAPI2.Repository.MovieRepo;
using AngularMovieAPI2.Repository.UserRepo;

namespace AngularMovieAPI2.Services.BookingsService
{
    public class TicketService : ITicketService
    {
        public IBookingRepository bookingRepo;
        public IMovieRepository movieRepo;
        public IUserRepository userRepo;
        public IPaymentRepository paymentRepo;
        public TicketService(
            IBookingRepository _bookingRepo,
            IMovieRepository movieRepo,
            IUserRepository userRepo,
            IPaymentRepository paymentRepo
            ) // Dependency Injection. 
        {

        }
        public Task<IEnumerable<Ticket>> getTickets(int userID)
        {
            throw new NotImplementedException();
        }
    }
}
