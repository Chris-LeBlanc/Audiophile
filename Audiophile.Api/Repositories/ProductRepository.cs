using System.Data;
using Audiophile.Models;
using Audiophile.Types;
using DAL;

namespace Audiophile.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly IDataAccess _db;
    public ProductRepository(IDataAccess dataAccess)
    {
        _db = dataAccess;
    }

    public async Task<ProductDto> GetProductAsync(int id)
    {
        DataTable dt = await _db.ExecuteAsync("spGetProduct", new List<Parm> { new("@ProductId", SqlDbType.Int, id)});

       if (dt.Rows.Count == 0)
        {
            return null;
        }

        DataRow row = dt.Rows[0];

        return new ProductDto(
            ProductId: Convert.ToInt32(row["id"]),
            Slug: row["slug"].ToString(),
            Name: row["name"].ToString(),
            CategoryId: Convert.ToInt32(row["categoryId"]),
            IsNew: Convert.ToBoolean(row["isNew"]),
            Price: Convert.ToDecimal(row["price"]),
            Description: row["description"].ToString(),
            Features: row["features"].ToString()
        );
    }

    public async Task<List<ProductDto>> GetProductsAsync()
    {
        DataTable dt = await _db.ExecuteAsync("spGetAllProducts");


        //TODO Images - Image path to render on client
        return dt.AsEnumerable().Select(row =>
        new ProductDto((int)row["ProductId"], row["Slug"].ToString(), row["Name"].ToString(), (int)row["CategoryId"], (bool)row["IsNew"], (int)row["Price"], row["Description"].ToString(), row["Features"].ToString())
        ).ToList();
    }
}
