using AngularMovieAPI2.Models.Snacks;
using AngularMovieAPI2.ModelsDto.SnackDto;

namespace AngularMovieAPI2.Services.SnackService
{
    public interface IOrderSnackService
    {
        public Task<IEnumerable<OrderSnack>> getOrderSnacks();
        public Task<OrderSnack> GetOrderSnackByID(int OrderSnackID);
        public Task<OrderSnack> CreateOrderSnack(OrderSnackDto createOrderSnack);
        public Task<OrderSnack> UpdateOrderSnack(OrderSnackDto updateOrderSnack, int OrderSnackID);
        public Task<OrderSnack> DeleteOrderSnack(int OrderSnackID);
    }
}
