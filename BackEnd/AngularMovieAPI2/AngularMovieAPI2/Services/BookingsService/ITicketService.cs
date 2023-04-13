using AngularMovieAPI2.Models.Bookings;

namespace AngularMovieAPI2.Services.BookingsService
{
    public interface ITicketService
    {
        public Task<IEnumerable<Ticket>> getTickets(int userID);
    }
}
