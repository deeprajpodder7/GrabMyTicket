using AngularMovieAPI2.Models.Snacks;
using AngularMovieAPI2.ModelsDto.SnackDto;

namespace AngularMovieAPI2.Repository.SnackRepo
{
    public interface IOrderSnackRepository
    {
        public Task<IEnumerable<OrderSnack>> getOrderSnacks();
        public Task<OrderSnack> GetOrderSnackByID(int OrderSnackID);
        public Task<OrderSnack> CreateOrderSnack(OrderSnackDto createOrderSnack);
        public Task<OrderSnack> UpdateOrderSnack(OrderSnackDto updateOrderSnack, int OrderSnackID);
        public Task<OrderSnack> DeleteOrderSnack(int OrderSnackID);
    }
}
