using Microsoft.EntityFrameworkCore;
using PTCGTrackerUI.Models;

using AspNet.Security.OAuth.Discord;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Connect to DB
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add repository interfaces
builder.Services.AddScoped<IDeckRepository, DeckRepository>();
builder.Services.AddScoped<IDeckCardRepository, DeckCardRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = "Discord";
})
.AddCookie()
.AddDiscord(options =>
{
    options.ClientId =
        builder.Configuration["Authentication:Discord:ClientId"]!;

    options.ClientSecret =
        builder.Configuration["Authentication:Discord:ClientSecret"]!;

    options.ClaimActions.MapJsonKey(
        ClaimTypes.Name,
        "username");
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
