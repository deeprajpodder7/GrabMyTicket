using AngularMovieAPI2.Models.Snacks;
using AngularMovieAPI2.ModelsDto.SnackDto;
using AngularMovieAPI2.Repository.SnackRepo;

namespace AngularMovieAPI2.Services.SnackService
{
    public class OrderSnackService : IOrderSnackService
    {
        public IOrderSnackRepository OrderSnackRepo;
        public OrderSnackService(IOrderSnackRepository _OrderSnackRepo)
        {
            OrderSnackRepo = _OrderSnackRepo;
        }





        public async Task<IEnumerable<OrderSnack>> getOrderSnacks() => await OrderSnackRepo.getOrderSnacks();
        public async Task<OrderSnack> GetOrderSnackByID(int OrderSnackID) => await OrderSnackRepo.GetOrderSnackByID(OrderSnackID);
        public async Task<OrderSnack> CreateOrderSnack(OrderSnackDto createOrderSnack) => await OrderSnackRepo.CreateOrderSnack(createOrderSnack);
        public async Task<OrderSnack> UpdateOrderSnack(OrderSnackDto updateOrderSnack, int OrderSnackID) => await OrderSnackRepo.UpdateOrderSnack(updateOrderSnack, OrderSnackID);
        public async Task<OrderSnack> DeleteOrderSnack(int OrderSnackID) => await OrderSnackRepo.DeleteOrderSnack(OrderSnackID);
    }
}
