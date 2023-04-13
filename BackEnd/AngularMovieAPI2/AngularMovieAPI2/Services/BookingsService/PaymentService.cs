using AngularMovieAPI2.Models.Bookings;
using AngularMovieAPI2.ModelsDto.BookingDto;
using AngularMovieAPI2.Repository.BookingRepo;

namespace AngularMovieAPI2.Services.BookingsService
{
    public class PaymentService : IPaymentService
    {
        public IPaymentRepository PaymentRepo;
        public PaymentService(IPaymentRepository _PaymentRepo)
        {
            PaymentRepo = _PaymentRepo;
        }





        public async Task<IEnumerable<Payment>> getPayments() => await PaymentRepo.getPayments();
        public async Task<Payment> GetPaymentByID(int PaymentID) => await PaymentRepo.GetPaymentByID(PaymentID);
        public async Task<Payment> CreatePayment(PaymentDto createPayment) => await PaymentRepo.CreatePayment(createPayment);
        public async Task<Payment> UpdatePayment(PaymentDto updatePayment, int PaymentID) => await PaymentRepo.UpdatePayment(updatePayment, PaymentID);
        public async Task<Payment> DeletePayment(int PaymentID) => await PaymentRepo.DeletePayment(PaymentID);
    }
}
