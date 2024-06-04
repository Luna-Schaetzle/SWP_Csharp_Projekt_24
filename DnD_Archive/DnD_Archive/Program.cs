using DnD_Archive.Models;
using DnD_Archive.Models.DB;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DnD_Archive.Hubs;
using System;

namespace DnD_Archive
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // DbContext als Singleton hinzufügen
            builder.Services.AddDbContext<DbManager>(ServiceLifetime.Singleton);

            // Session hinzufügen
            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSignalR();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // Authentifizierung hinzufügen
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Start/Index"; // Pfad zur Anmeldeseite
                });

            // MarkdownService als Singleton hinzufügen
            builder.Services.AddSingleton<MarkdownService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Session und Authentifizierungsmiddleware hinzufügen
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapHub<ChatHub>("/chatHub");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Start}/{action=Index}/{id?}");

            // Führt die app aus!
            app.Run();
        }
    }
}