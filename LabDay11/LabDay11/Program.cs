using LabDay11.Data;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        // Đăng ký DbContext với SQL Server
        builder.Services.AddDbContext<SchoolContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolContext")));

        // Đăng ký Database Error Page
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        var app = builder.Build();

        // Seed data
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            DbInitializer.Initialize(services);
        }

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();

        app.MapControllerRoute(
            name: "StudentListRoute",
            pattern: "Admin/Student/List",
            defaults: new { controller = "Student", action = "Index" });

        app.MapControllerRoute(
            name: "StudentAddRoute",
            pattern: "Admin/Student/Add",
            defaults: new { controller = "Student", action = "Create" });

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();

        app.Run();
    }
}
