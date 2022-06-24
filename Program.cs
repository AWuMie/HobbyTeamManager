using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using HobbyTeamManager.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using HobbyTeamManager.Services;
using HobbyTeamManager.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

#region database connection
var connectionString = builder.Configuration.GetConnectionString("ConnectionString");
#if RELEASE
var connectionString = builder.Configuration.GetConnectionString("ReleaseConnection");
#endif
builder.Services.AddDbContext<HobbyTeamManagerContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
#endregion

#region Session stuff
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "HTM.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(15);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
#endregion

#region authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.SlidingExpiration = true;
        options.AccessDeniedPath = "/Account/AccessDenied/";
        
        options.Events = new CookieAuthenticationEvents
        {
            OnValidatePrincipal = CookieValidator.ValidateAsync
        };
    });
#endregion

#region authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admins", policy =>
    {
        policy.RequireRole(Player.AdminRole);
    });
    options.AddPolicy("Users", policy =>
    {
        policy.RequireRole(Player.UserRole);
    });
});

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Sites", "Admins")
        .AuthorizePage("/Sites/Details", "Users")
        .AuthorizePage("/Sites/Index", "Users");

    options.Conventions.AuthorizeFolder("/Seasons", "Admins")
        .AuthorizePage("/Seasons/Details", "Users")
        .AuthorizePage("/Seasons/Index", "Users");

    options.Conventions.AuthorizeFolder("/Players", "Admins")
        .AuthorizePage("/Players/Details", "Users")
        .AuthorizePage("/Players/Index", "Users")
        .AllowAnonymousToPage("/Players/Galery");

    options.Conventions.AuthorizeFolder("/MatchDays", "Admins")
        .AuthorizePage("/MatchDays/Details", "Users")
        .AuthorizePage("/MatchDays/Index", "Users");

    options.Conventions.AuthorizeFolder("/Teams", "Admins")
        .AuthorizePage("/Teams/Details", "Users")
        .AuthorizePage("/Teams/Index", "Users");
});
#endregion

var app = builder.Build();

#region database seeding
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}
#endregion

#region reverse proxy stuff
// reverse proxy stuff - see "https://thomaslevesque.com/2018/04/17/hosting-an-asp-net-core-2-application-on-a-raspberry-pi/"
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});
app.Use(async (context, next) =>
{
    var forwardedPath = context.Request.Headers["X-Forwarded-Path"].FirstOrDefault();
    if (!string.IsNullOrEmpty(forwardedPath))
    {
        context.Request.PathBase = forwardedPath;
    }
    await next();
});
#endregion

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

#region Session stuff 2 && authentication 2 (cookie stuff)
var cookiePolicyOptions = new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
};
app.UseCookiePolicy(cookiePolicyOptions);
app.UseSession();
#endregion

app.MapRazorPages();

app.Run();
