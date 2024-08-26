using lab1.services;
using lab1.interfaces;

namespace lab1;

class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        BuildServices(builder);
        BuildDataBase(builder);

        var app = builder.Build();

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
    }

    private static void BuildDataBase(WebApplicationBuilder builder) {
        // TODO: Add services to the container
    }
}


