using AngularMovieAPI2.Models.Bookings;
using AngularMovieAPI2.ModelsDto.BookingDto;

namespace AngularMovieAPI2.Services.BookingsService
{
    public interface IPaymentService
    {
        public Task<IEnumerable<Payment>> getPayments();
        public Task<Payment> GetPaymentByID(int PaymentID);
        public Task<Payment> CreatePayment(PaymentDto createPayment);
        public Task<Payment> UpdatePayment(PaymentDto updatePayment, int PaymentID);
        public Task<Payment> DeletePayment(int PaymentID);
    }
}
