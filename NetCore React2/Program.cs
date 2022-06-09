using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using NetCore_React2.Data;
using NetCore_React2.Models;
//using Microsoft.AspNetCore.Http;
//using JavaScriptEngineSwitcher.V8;
//using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
//using React.AspNet;

//services.AddControllersWithViews();
//services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//services.AddReact();

//// Make sure a JS engine is registered, or you will get an error!
//services.AddJsEngineSwitcher(options => options.DefaultEngineName = V8JsEngine.EngineName)
//  .AddV8();

//app.UseStaticFiles();

//// Initialise ReactJS.NET. Must be before static files.
//app.UseReact(config =>
//{
//    // If you want to use server-side rendering of React components,
//    // add all the necessary JavaScript files here. This includes
//    // your components as well as all of their dependencies.
//    // See http://reactjs.net/ for more information. Example:
//    //config
//    //  .AddScript("~/js/First.jsx")
//    //  .AddScript("~/js/Second.jsx");

//    // If you use an external build too (for example, Babel, Webpack,
//    // Browserify or Gulp), you can improve performance by disabling
//    // ReactJS.NET's version of Babel and loading the pre-transpiled
//    // scripts. Example:
//    //config
//    //  .SetLoadBabel(false)
//    //  .AddScriptWithoutTransform("~/js/bundle.server.js");
//});


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentityServer()
    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

builder.Services.AddAuthentication()
    .AddIdentityServerJwt();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseIdentityServer();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");
app.MapRazorPages();

app.MapFallbackToFile("index.html"); ;

app.Run();
