using KoiPond.Repositories.Models;
using KoiPond.Repositories;
using KoiPond.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using KoiPond.Repositories.Repositories;
using KoiPond.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Register Repositories and Services
builder.Services.AddScoped<IYeuCauThiCongRepository, YeuCauThiCongRepository>();
builder.Services.AddScoped<IYeuCauThiCongService, YeuCauThiCongService>();

builder.Services.AddScoped<IYeuCauDichVuRepository, YeuCauDichVuRepository>();
builder.Services.AddScoped<IYeuCauDichVuService, YeuCauDichVuService>();

builder.Services.AddScoped<IKhachHangService, KhachHangService>();
builder.Services.AddScoped<IKhachHangRepository, KhachHangRepository>();

builder.Services.AddScoped<INhanVienRepository, NhanVienRepository>();
builder.Services.AddScoped<INhanVienService, NhanVienService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IDanhGiaPhanHoiRepository, DanhGiaPhanHoiRepository>();
builder.Services.AddScoped<IDanhGiaPhanHoiService, DanhGiaPhanHoiService>();

builder.Services.AddScoped<ISanPhamRepository, SanPhamRepository>();
builder.Services.AddScoped<ISanPhamService, SanPhamService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure Entity Framework and Identity with ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConStr")));

// Configure Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Configure IdentityOptions
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;
});

// Build the app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Add authentication and authorization middleware
app.UseAuthentication();
app.UseAuthorization();

// Define the default route for controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
