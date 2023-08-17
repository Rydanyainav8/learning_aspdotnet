using learning_aspdotnet.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ScratchShopAppDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ScratchShopAppDbContextConnection' not found.");

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

//sp = service provider
builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();


builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
     {
         options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
     });
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ScratchShopAppDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:ScratchShopAppDbContextConnection"]);
});

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ScratchShopAppDbContext>();

//for blazor dynamic UI
builder.Services.AddServerSideBlazor();

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

//"{controller=Home/{action=Index}/{id}
app.MapDefaultControllerRoute();
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}"
//);
app.MapRazorPages();

//routing api
app.MapControllers();

app.MapBlazorHub();
app.MapFallbackToPage("/app/{*catchall}", "/App/Index");

DbInitializer.Seed(app);
app.Run();
