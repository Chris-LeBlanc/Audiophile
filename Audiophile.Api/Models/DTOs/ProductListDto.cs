namespace Audiophile.Models
{
    public record ProductListDto(Guid id, string name, string description, decimal price, string image);
}