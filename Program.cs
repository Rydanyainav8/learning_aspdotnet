using learning_aspdotnet.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

//sp = service provider
builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor(); 


builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ScratchShopAppDbContext>(options => {
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:ScratchShopAppDbContextConnection"]);
}); 


var app = builder.Build(); 

app.UseStaticFiles();
app.UseSession();

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

DbInitializer.Seed(app);   
app.Run();
