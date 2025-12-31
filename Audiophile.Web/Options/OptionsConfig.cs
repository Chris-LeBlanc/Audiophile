namespace Audiophile.Options;

public class OptionsConfig
{
    public const string SectionName = "ApiEndpoints";

    public string? BaseUrl { get; set; }

    public string? Products { get; set; }
}
