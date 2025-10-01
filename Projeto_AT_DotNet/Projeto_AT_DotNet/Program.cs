using Microsoft.EntityFrameworkCore;
using Projeto_AT_DotNet.Data;

namespace Projeto_AT_DotNet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AgenciaContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
             );

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddAuthentication("CookieAuth")
                            .AddCookie("CookieAuth", options =>
                            {
                                options.LoginPath = "/Account/Login";

                                options.AccessDeniedPath = "/AccessDenied";

                                options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                            });

            // 2. Configura a Autorização
            builder.Services.AddAuthorization();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
