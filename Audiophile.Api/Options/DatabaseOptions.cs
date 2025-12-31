using Microsoft.Identity.Client;
using Microsoft.Net.Http.Headers;

namespace Audiophile.Options;

public class DatabaseOptions
{
    public const string SectionName = "ConnectionStrings";

    public string AudiophileConnStr { get; set; } = string.Empty;
}
