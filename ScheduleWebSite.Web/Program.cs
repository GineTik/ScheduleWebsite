using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using ScheduleWebSite.Data.Contexts;



var builder = WebApplication.CreateBuilder(args);


// add services
builder.Services.AddMvc();
builder.Services.AddDbContext<ScheduleContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddTransient<ScheduleContext>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(options => //CookieAuthenticationOptions
{
    options.LoginPath = new PathString("/Authorization/SignIn");
});


var app = builder.Build();


// mapping
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
// authorization
app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();

app.Run();