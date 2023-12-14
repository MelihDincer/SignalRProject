using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using SignalR.DataAccessLayer.Concrete;
using SignalR.EntityLayer.Entities;

var builder = WebApplication.CreateBuilder(args);

var requireAuthorizePolicy= new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build(); //Authenticated kullan�c�y� zorunlu k�l.
// Add services to the container.
builder.Services.AddDbContext<SignalRContext>();
//Register Konfig�rasyonu
builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<SignalRContext>();
builder.Services.AddHttpClient();
//B�t�n controllerlarda a�a��daki filtreyi uygula
builder.Services.AddControllersWithViews(opt =>
{
   opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
});

builder.Services.ConfigureApplicationCookie(opts =>
{
    opts.LoginPath = "/Login/Index/";
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
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
