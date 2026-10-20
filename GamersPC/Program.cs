using efcoreApp.Data;
using GamersPC.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddRazorPages()
    .AddRazorPagesOptions(options =>
    {
        options.Conventions.AuthorizePage("/UserProfile");
        options.Conventions.AuthorizePage("/UserEdit");
    });
builder.Services.AddSingleton<IHttpContextAccessor , HttpContextAccessor>();
builder.Services.AddScoped<PaymentList>(sc =>SessionPaymentList.GetPaymentList(sc));
builder.Services.AddScoped<WishList>(sc =>SessionWishList.GetWishList(sc));


builder.Services.AddScoped<IOrderRepository , EfOrderRepository>();
builder.Services.AddDbContext<IdentityContext>(
    options => options.UseSqlite(builder.Configuration["ConnectionStrings:SQLite_Connection"]));

builder.Services.AddIdentity<User, Role>().AddEntityFrameworkStores<IdentityContext>();

builder.Services.Configure<IdentityOptions>(options => {
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = "/Account/Login";
            options.LogoutPath = "/Account/Logout";
        });


builder.Services.ConfigureApplicationCookie(options => {
    options.AccessDeniedPath = "/Account/AccesDenied";
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(30);
});
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

IdentitySeedData.IdentityTestUser(app);

app.Run();
 