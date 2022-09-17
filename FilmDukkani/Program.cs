using FilmDukkani;
using FilmDukkani.AutoMapper;
using FilmDukkani.BL.Abstract;
using FilmDukkani.BL.Concrete;
using FilmDukkani.DAL;
using FilmDukkani.DAL.Abstract;
using FilmDukkani.DAL.Concrete;
using FilmDukkani.DAL.Contexts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SqlDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("FilmDukkan")));


builder.Services.AddAutoMapper(typeof(FilmDukkaniProfile));




builder.Services.AddScoped<IKullaniciManager, KullaniciManager>();
builder.Services.AddScoped<IKategoriManager, KategoriManager>();
builder.Services.AddScoped<IFilmManager, FilmManager>();
builder.Services.AddScoped<ISepetManager, SepetManager>();
builder.Services.AddScoped<IAdresManager, AdresManager>();





builder.Services.AddIdentity<AppUser, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedPhoneNumber = false;
    x.SignIn.RequireConfirmedEmail = false;
    x.SignIn.RequireConfirmedAccount = false;

    x.Password.RequiredLength = 3;
    x.Password.RequireUppercase = false;
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequiredUniqueChars = 0;
    x.Password.RequireLowercase = false;

}).AddEntityFrameworkStores<SqlDbContext>().AddDefaultTokenProviders();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "default",
      pattern: "{controller=Home}/{action=Index}/{id?}"
    );
    //endpoints.MapControllerRoute(
    //        name: "areas",
    //        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    //        );
});


app.Run();
