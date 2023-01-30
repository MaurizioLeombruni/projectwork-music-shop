using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShopStrumentiMusicali.Database;
using ShopStrumentiMusicali.Repositories;

var builder = WebApplication.CreateBuilder(args);
//string connectionString = builder.Configuration.GetConnectionString("ParamusicContextConnection") ?? throw new InvalidOperationException("Connection string 'ParamusicContextConnection' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ParamusicContext>();      
builder.Services.AddDefaultIdentity<IdentityUser>().AddDefaultTokenProviders().AddRoles<IdentityRole>().AddEntityFrameworkStores<ParamusicContext>();

//(options => options.SignIn.RequireConfirmedAccount = true)

AddScoped();

var app = builder.Build();

app.MapRazorPages();



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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


void AddScoped(){ 
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IUnitofWork, UnitOfWork>();

}