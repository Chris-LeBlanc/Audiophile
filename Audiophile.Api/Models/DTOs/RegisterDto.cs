namespace Audiophile.Models
{
    public record RegisterDto(Guid UserId, string Name, string Address, string PostalCode, string City, string Country);
} 