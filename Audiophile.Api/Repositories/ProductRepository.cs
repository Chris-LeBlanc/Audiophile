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
        DataTable dt = await _db.ExecuteAsync("spGetProduct", new List<Parm> { new("@Id", SqlDbType.Int, id)});

       if (dt.Rows.Count == 0)
        {
            throw new KeyNotFoundException($"Product with Id {id} not found");
        }

        DataRow row = dt.Rows[0];

        return new ProductDto(
            ProductId: Convert.ToInt32(row["ProductId"]),
            Slug: row["slug"].ToString(),
            Name: row["name"].ToString(),
            CategoryId: Convert.ToInt32(row["CategoryId"]),
            IsNew: Convert.ToBoolean(row["IsNew"]),
            Price: Convert.ToDecimal(row["Price"]),
            Description: row["Description"].ToString(),
            Features: row["Features"].ToString()
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
