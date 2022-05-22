using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MovieShopMVC.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// .Net Core has built-in Dependency Injection, first class citizen in .Net Core
// registrations: register service for the interface
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<ICastService, CastService>();
builder.Services.AddScoped<ICastRepository, CastRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICurrentUser, CurrentUser>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IFavoriteRepository, FavoriteRepository>();
builder.Services.AddScoped<IPurchaseRepository, PurchaseRepository>();
builder.Services.AddScoped<IGenreService, GenreService>();


builder.Services.AddHttpContextAccessor();

// scope in DI
// AddScoped => Http Request, its gonna create the instance, reuse the instance within the http request, when a new http request, new instance
// AddTransient => it will create new instance each and every time
// AddSingleton => its gonna create instance when the first request comes in and it will reuse until application shuts down => one instance

// older.Net framework, then to do dependancy injection, we had to rely on 3rd party libraries such as AutoFac, Ninject

// Inject DbContextOptions with connection string into MovieShopDbContext
builder.Services.AddDbContext<MovieShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieShopDbConnection"));
});

// cookie info
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "MovieShopAuthCookie";
        // expiration time: 2h
        options.ExpireTimeSpan = TimeSpan.FromHours(2);
        // if timesout, redirect to login page
        options.LoginPath = "/account/login";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Middleware in ASP.NET Core
// here app. are all middleware, have some basic default to be use for every microsoft projects here
// many built in middlewares, use based on needs
// order of middlewares matters!
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Auth process
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();