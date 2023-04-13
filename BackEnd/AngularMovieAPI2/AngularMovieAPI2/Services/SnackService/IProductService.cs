using AngularMovieAPI2.Models.Snacks;
using AngularMovieAPI2.ModelsDto.SnackDto;

namespace AngularMovieAPI2.Services.SnackService
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> getProducts();
        public Task<Product> GetProductByID(int ProductID);
        public Task<Product> CreateProduct(ProductDto createProduct);
        public Task<Product> UpdateProduct(ProductDto updateProduct, int ProductID);
        public Task<Product> DeleteProduct(int ProductID);
    }
}
