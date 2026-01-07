namespace Audiophile.Views;

public class ProductViewModel
{
    public int ProductId { get; set; }

    public string? Slug {get; set;}

    public string? Name { get; set; }

    public int CategoryId {get; set;}

    public bool IsNew {get; set;}

    public decimal Price { get; set; }

    public string? Description { get; set; }

    public string? Features {get; set;}
}