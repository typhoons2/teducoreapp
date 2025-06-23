using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using TeduCoreApp.Application.AutoMapper;
using TeduCoreApp.Application.Implementations;
using TeduCoreApp.Application.Interfaces;
using TeduCoreApp.Data.EF;
using TeduCoreApp.Data.EF.Repositories;
using TeduCoreApp.Data.Entities;
using TeduCoreApp.Data.IRepositories;
using TeduCoreApp.Helpers;
using TeduCoreApp.Infrastructure.Interfaces;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString, o => o.MigrationsAssembly("TeduCoreApp.Data.EF")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddTransient<DbInitializer>();

builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Admin/Login/Index";
});

builder.Services.AddScoped<UserManager<AppUser>, UserManager<AppUser>>();
builder.Services.AddScoped<RoleManager<AppRole>, RoleManager<AppRole>>();
builder.Services.AddScoped<IUserClaimsPrincipalFactory<AppUser>, CustomClaimsPrincipalFactory>();


Log.Logger = new LoggerConfiguration()
	.WriteTo.Console()
	.WriteTo.File("Logs/tedu-.txt", rollingInterval: RollingInterval.Day)
	.CreateLogger();



builder.Host.UseSerilog();


builder.Services.AddAutoMapper(typeof(ViewModelToDomainMappingProfile).Assembly);
//builder.Services.AddAutoMapper(typeof(ViewModelToDomainMappingProfile));
//builder.Services.AddAutoMapper(typeof(DomainToViewModelMappingProfile));    

builder.Services.AddTransient<IUnitOfWork, EFUnitOfWork>();
/// Repositories
builder.Services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IFunctionRepository, FunctionRepository>();

// Services
builder.Services.AddTransient<IProductCategoryService, ProductCategoryService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IFunctionService, FunctionService>();

//builder.Services.AddControllersWithViews()
//    .AddNewtonsoftJson(options =>
//    {
//        options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
//    });

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); //




var app = builder.Build();

// Seed dữ liệu mẫu khi khởi động ứng dụng
using (var scope = app.Services.CreateScope())
{
    var dbInitializer = scope.ServiceProvider.GetRequiredService<DbInitializer>();
    dbInitializer.Seed().Wait(); // Nếu muốn await, cần đổi Main thành async
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())    
{
    app.UseMigrationsEndPoint();
}
else
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

/*
 * Cấu trúc URL sau khi thêm route này sẽ là:
URL thông thường: /Home/Index
URL có Area: /Admin/Home/Index
Bây giờ bạn có thể truy cập các controller trong Area Admin thông qua URL có prefix /Admin/. Ví dụ:
/Admin/Home/Index
/Admin/Product/List
/Admin/User/Manage
 * Route Areas phải được định nghĩa trước route mặc định
Nếu không, các request đến Area sẽ không được xử lý đúng
 */
app.MapControllerRoute(
    name: "areaRoute",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
    //pattern: "{controller=Login}/{action=Index}/{id?}",
    //defaults: new { area = "Admin" });
app.MapRazorPages();

app.Run();
