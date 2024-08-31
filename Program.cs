
using Microsoft.EntityFrameworkCore;
// 
using lab1.services;
using lab1.interfaces;
using lab1.data;

namespace lab1;

class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        BuildServices(builder);
        BuildDataBase(builder);

        var app = builder.Build();

        BuildInitialize(app);

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        Route.RouteConfig(app);

        app.Run();
    }

    private static void BuildServices(WebApplicationBuilder builder) {
        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddTransient<IBufferedFileUploadService, BufferedFileUploadLocalService>();
        builder.Services.AddTransient<IBufferedFileUploadService, ImageService>();
        builder.Services.AddTransient<IStreamFileUploadService, StreamFileUploadLocalService>();
    }

    private static void BuildDataBase(WebApplicationBuilder builder) {
        // TODO: Add services to the container
        builder.Services.AddDbContext<SchoolContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        
    }

    private static void BuildInitialize(WebApplication app) {
        // Initialize the database
        using (var serviceScope = app.Services.CreateScope())
        {
            var services = serviceScope.ServiceProvider;
            var context = services.GetRequiredService<SchoolContext>();
            DbInitializer.Initialize(services);
        }
    }
}


