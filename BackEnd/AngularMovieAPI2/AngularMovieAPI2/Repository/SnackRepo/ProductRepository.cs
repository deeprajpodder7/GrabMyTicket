using AngularMovieAPI2.Environment;
using AngularMovieAPI2.Helper;
using AngularMovieAPI2.Models.Snacks;
using AngularMovieAPI2.ModelsDto.SnackDto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AngularMovieAPI2.Repository.SnackRepo
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext context;
        private IMapper mapper;
        public ProductRepository(ApplicationDbContext _context, IMapper _mapper) // Dependency Injection
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task<Product> CreateProduct(ProductDto createProduct)
        {
            var Product = mapper.Map<Product>(createProduct);
            await context.Products.AddAsync(Product);
            await context.SaveChangesAsync();
            return Product;
        }

        public async Task<Product> DeleteProduct(int ProductID)
        {
            var deleteProduct = await context.Products.FindAsync(ProductID);
            if (deleteProduct != null)
            {
                context.Products.Remove(deleteProduct);
                await context.SaveChangesAsync();
            }
            return deleteProduct;

        }

        public async Task<Product> GetProductByID(int ProductID)
        {
            return await context.Products.FindAsync(ProductID);

        }

        public async Task<IEnumerable<Product>> getProducts()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<Product> UpdateProduct(ProductDto UpdateProduct, int ProductID)
        {
            var updatedProduct = mapper.Map<Product>(UpdateProduct);
            var Product = await context.Products.FindAsync(ProductID);
            if (Product == null)
            {
                throw new AppException("Product not found");

            }
            if (!string.IsNullOrWhiteSpace(updatedProduct.Name.ToString()))
            {
                Product.Name = updatedProduct.Name;
            }
            if (!string.IsNullOrWhiteSpace(updatedProduct.Price.ToString()))
            {
                Product.Price = updatedProduct.Price;
            }
            if (!string.IsNullOrWhiteSpace(updatedProduct.Description.ToString()))
            {
                Product.Description = updatedProduct.Description;
            }

            context.Products.Update(Product);
            await context.SaveChangesAsync();

            return Product;

        }
    }
}
