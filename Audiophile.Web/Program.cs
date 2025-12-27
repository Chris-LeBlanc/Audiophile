using Audiophile.Options;
using Audiophile.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.Configure<OptionsConfig>(
    builder.Configuration.GetSection(OptionsConfig.SectionName));

builder.Services.AddHttpClient("OptionsConfig", (sp, client) =>
{
   var options = sp.GetRequiredService<IOptions<OptionsConfig>>().Value;
   client.BaseAddress = new Uri(options.BaseUrl); 
});

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
