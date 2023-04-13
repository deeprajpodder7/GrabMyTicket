using AngularMovieAPI2.Models.Snacks;
using AngularMovieAPI2.ModelsDto.SnackDto;
using AngularMovieAPI2.Repository.SnackRepo;

namespace AngularMovieAPI2.Services.SnackService
{
    public class ProductService : IProductService
    {
        public IProductRepository ProductRepo;
        public ProductService(IProductRepository _ProductRepo)
        {
            ProductRepo = _ProductRepo;
        }



        public async Task<IEnumerable<Product>> getProducts() => await ProductRepo.getProducts();
        public async Task<Product> GetProductByID(int ProductID) => await ProductRepo.GetProductByID(ProductID);
        public async Task<Product> CreateProduct(ProductDto createProduct) => await ProductRepo.CreateProduct(createProduct);
        public async Task<Product> UpdateProduct(ProductDto updateProduct, int ProductID) => await ProductRepo.UpdateProduct(updateProduct, ProductID);
        public async Task<Product> DeleteProduct(int ProductID) => await ProductRepo.DeleteProduct(ProductID);
    }
}
