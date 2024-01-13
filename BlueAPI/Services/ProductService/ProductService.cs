using BlueAPI.Data;
using BlueAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlueAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly BlueDB _database;

        public ProductService(BlueDB database)
        {
            this._database = database;
        }


        public async Task<Product?> GetProductById(int id)
        {
            return await this._database
                        .Product
                        .Include(p => p.Status)
                        .FirstOrDefaultAsync(p => p.Id == id && p.StatusId == (int)ProductStatus.Active);
        }

        public async Task InsertProduct(Product entity)
        {
            this._database.Product.Add(entity);
            await this._database.SaveChangesAsync();
            await this._database.Entry(entity).Reference(p => p.Status).LoadAsync();
        }

        public async Task UpdateProduct(Product entity)
        {
            this._database.Product.Update(entity);
            await this._database.SaveChangesAsync();
            await this._database.Entry(entity).Reference(p => p.Status).LoadAsync();
        }
    }
}
