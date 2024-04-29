using AdManage.Application.Features.CQRS.Handlers;
using AdManage.Application.Interfaces;
using AdManage.Persistence.DbContexts;
using AdManage.Persistence.Repositories;
using AdManageWeb.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AdManageWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddHttpClient();

            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .SetIsOriginAllowed((host) => true)
                    .AllowCredentials();
                });
            });

            builder.Services.AddScoped<AdManageDbContext>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            builder.Services.AddScoped(typeof(IBronzeRepository), typeof(BronzeRepository));

            builder.Services.AddScoped<GetBronzeQueryHandler>();
            builder.Services.AddScoped<GetBronzeByIdQueryHandler>();
            builder.Services.AddScoped<CreateBronzeCommandHandler>();
            builder.Services.AddScoped<UpdateBronzeCommandHandler>();
            builder.Services.AddScoped<RemoveBronzeCommandHandler>();



            // Add services to the container.
            builder.Services.AddControllersWithViews();

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



            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.Run();
        }
    }

}
