using System.Data;
using Audiophile.Models;
using DAL;

namespace Audiophile.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDataAccess _db;
        public ProductRepository(IDataAccess dataAccess)
        {
            _db = dataAccess;
        }
        public async Task<List<ProductListDto>> GetProductsAsync()
        {
            DataTable dt = await _db.ExecuteAsync("spGetAllProducts");

            return dt.AsEnumerable().Select(row => 
            new ProductListDto((Guid)row["ProductId"], row["Name"].ToString(), row["Description"].ToString(), (decimal)row["Price"])
            ).ToList();
        }
    }
}