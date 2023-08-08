using learning_aspdotnet.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ScratchShopAppDbContext>(options => {
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:ScratchShopAppDbContextConnection"]);
});


var app = builder.Build(); 
app.UseStaticFiles();
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
