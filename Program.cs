
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
// 
using lab1.services;
using lab1.interfaces;
using lab1.data;
using lab1.models;
using lab1.helpers;

namespace lab1;

class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        BuildAuthentication(builder);
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

    private static void BuildAuthentication(WebApplicationBuilder builder)
    {
        var jwtSettings = builder.Configuration.GetSection("Jwt");
        var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings["Issuer"],
                ValidAudience = jwtSettings["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };
        });

    }

    private static void BuildServices(WebApplicationBuilder builder)
    {
        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddTransient<IBufferedFileUploadService, BufferedFileUploadLocalService>();
        builder.Services.AddTransient<IBufferedFileUploadService, ImageService>();
        builder.Services.AddTransient<IStreamFileUploadService, StreamFileUploadLocalService>();

        // Add service helpper 
        builder.Services.AddScoped<JwtHelper>();
    }

    private static void BuildDataBase(WebApplicationBuilder builder)
    {
        // TODO: Add services to the container
        builder.Services.AddDbContext<SchoolContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Register the ViewContext 
        builder.Services.AddDbContext<ViewContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Register the IdentityContext
        builder.Services.AddDbContext<IdentityContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Register Identity services
        builder.Services.AddIdentity<IdentityUserCustom, IdentityRole>()
            .AddEntityFrameworkStores<IdentityContext>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();
    }

    private static void BuildInitialize(WebApplication app)
    {
        // Initialize the database
        using (var serviceScope = app.Services.CreateScope())
        {
            var services = serviceScope.ServiceProvider;
            var context = services.GetRequiredService<SchoolContext>();
            DbInitializer.Initialize(services);
        }
    }
}


