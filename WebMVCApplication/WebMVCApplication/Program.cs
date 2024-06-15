using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebMVCApplication.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// ���U DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(@"Server=.\SQLExpress;Database=TodoDB;Trusted_Connection=True;ConnectRetryCount=0"));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<TodoManageRepository>();
builder.Services.AddScoped<TodoManageEFCoreRepository>();


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
