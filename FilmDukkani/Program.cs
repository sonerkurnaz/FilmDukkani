using FilmDukkani.AutoMapper;
using FilmDukkani.BL.Abstract;
using FilmDukkani.BL.Concrete;
using FilmDukkani.DAL;
using FilmDukkani.DAL.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SqlDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("FilmDukkan")));
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

builder.Services.AddAutoMapper(typeof(FilmDukkaniProfile));




builder.Services.AddScoped<IKullaniciManager, KullaniciManager>();
builder.Services.AddScoped<IKategoriManager, KategoriManager>();
builder.Services.AddScoped<IFilmManager, FilmManager>();



//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(options =>
//    {
//        options.LoginPath = "/User/Login";
//        options.LogoutPath = "/User/Logout";
//        options.AccessDeniedPath = "/User/Yasak";
//        options.Cookie.Name = "FilmDukkan";
//        options.Cookie.HttpOnly = true;
//        options.Cookie.SameSite = SameSiteMode.Strict;
//    });

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
    endpoints.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );
});


app.Run();
