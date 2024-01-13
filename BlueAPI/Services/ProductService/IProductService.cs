using BlueAPI.Data.Models;

namespace BlueAPI.Services
{
    public interface IProductService
    {
        Task<Product?> GetProductById(int id);
        Task InsertProduct(Product entity);
        Task UpdateProduct(Product entity);

    }
}
