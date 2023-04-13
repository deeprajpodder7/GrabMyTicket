using AngularMovieAPI2.Environment;
using AngularMovieAPI2.Helper;
using AngularMovieAPI2.Models.Snacks;
using AngularMovieAPI2.ModelsDto.SnackDto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AngularMovieAPI2.Repository.SnackRepo
{
    public class OrderSnackRepository : IOrderSnackRepository
    {

        private readonly ApplicationDbContext context;
        private IMapper mapper;
        public OrderSnackRepository(ApplicationDbContext _context, IMapper _mapper) // Dependency Injection
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task<OrderSnack> CreateOrderSnack(OrderSnackDto createOrderSnack)
        {
            var OrderSnack = mapper.Map<OrderSnack>(createOrderSnack);
            await context.OrderSnacks.AddAsync(OrderSnack);
            await context.SaveChangesAsync();
            return OrderSnack;
        }

        public async Task<OrderSnack> DeleteOrderSnack(int OrderSnackID)
        {
            var deleteOrderSnack = await context.OrderSnacks.FindAsync(OrderSnackID);
            if (deleteOrderSnack != null)
            {
                context.OrderSnacks.Remove(deleteOrderSnack);
                await context.SaveChangesAsync();
            }
            return deleteOrderSnack;

        }

        public async Task<OrderSnack> GetOrderSnackByID(int OrderSnackID)
        {
            return await context.OrderSnacks.FindAsync(OrderSnackID);

        }

        public async Task<IEnumerable<OrderSnack>> getOrderSnacks()
        {
            return await context.OrderSnacks.Include(os => os.Booking).Include(os => os.Product).ToListAsync();
        }

        public async Task<OrderSnack> UpdateOrderSnack(OrderSnackDto UpdateOrderSnack, int OrderSnackID)
        {
            var updatedOrderSnack = mapper.Map<OrderSnack>(UpdateOrderSnack);
            var OrderSnack = await context.OrderSnacks.FindAsync(OrderSnackID);
            if (OrderSnack == null)
            {
                throw new AppException("OrderSnack not found");

            }
            if (!string.IsNullOrWhiteSpace(updatedOrderSnack.Quantity.ToString()))
            {
                OrderSnack.Quantity = updatedOrderSnack.Quantity;
            }
            if (!string.IsNullOrWhiteSpace(updatedOrderSnack.ProductID.ToString()))
            {
                OrderSnack.ProductID = updatedOrderSnack.ProductID;
            }
            if (!string.IsNullOrWhiteSpace(updatedOrderSnack.BookingID.ToString()))
            {
                OrderSnack.BookingID = updatedOrderSnack.BookingID;
            }

            context.OrderSnacks.Update(OrderSnack);
            await context.SaveChangesAsync();

            return OrderSnack;

        }
    }
}
