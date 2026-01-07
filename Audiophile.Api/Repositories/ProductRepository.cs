using System.Data;
using Audiophile.Models;
using DAL;

namespace Audiophile.Repositories;

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
        new ProductListDto((int)row["ProductId"], row["Slug"].ToString(), row["Name"].ToString(), (int)row["CategoryId"], (bool)row["IsNew"], (int)row["Price"], row["Description"].ToString(), row["Features"].ToString())
        ).ToList();
    }
}
