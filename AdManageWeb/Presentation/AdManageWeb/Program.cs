using AdManageWeb.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AdManage.Application.Features.CQRS.Handlers;
using AdManage.Application.Interfaces;
using AdManage.Persistence.DbContexts;
using AdManage.Persistence.Repositories;
using AdManage.Domain.Entities;
using AdManageWeb.Models;

namespace AdManageWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // DbContext'i ekleyin
            builder.Services.AddDbContext<AdManageDbContext>();

			builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AdManageDbContext>().AddErrorDescriber<CustomIdentityValidator>().AddEntityFrameworkStores<AdManageDbContext>();


			// Diğer servisleri ekleyin
			builder.Services.AddControllersWithViews();
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

            // Repository ve Handler'ları ekleyin
            builder.Services.AddScoped<AdManageDbContext>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            builder.Services.AddScoped(typeof(IBronzeRepository), typeof(BronzeRepository));

            builder.Services.AddScoped<GetBronzeQueryHandler>();
            builder.Services.AddScoped<GetBronzeByIdQueryHandler>();
            builder.Services.AddScoped<CreateBronzeCommandHandler>();
            builder.Services.AddScoped<UpdateBronzeCommandHandler>();
            builder.Services.AddScoped<RemoveBronzeCommandHandler>();

            builder.Services.AddScoped(typeof(IGoldRepository), typeof(GoldRepository));

            builder.Services.AddScoped<GetGoldQueryHandler>();
            builder.Services.AddScoped<GetGoldByIdQueryHandler>();
            builder.Services.AddScoped<CreateGoldCommandHandler>();
            builder.Services.AddScoped<UpdateGoldCommandHandler>();
            builder.Services.AddScoped<RemoveGoldCommandHandler>();

            builder.Services.AddScoped(typeof(ISilverRepository), typeof(SilverRepository));

            builder.Services.AddScoped<GetSilverQueryHandler>();
            builder.Services.AddScoped<GetSilverByIdQueryHandler>();
            builder.Services.AddScoped<CreateSilverCommandHandler>();
            builder.Services.AddScoped<UpdateSilverCommandHandler>();
            builder.Services.AddScoped<RemoveSilverCommandHandler>();

            var app = builder.Build();

            // Middleware'leri yapılandırın
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            // Endpoint'leri eşleştirin
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.UseEndpoints(endpoints =>
            {
               
                endpoints.MapControllerRoute(
                  name: "UserProcedures",
                  pattern: "{area:exists}/{controller=Login}/{action=Login}/{id?}");
            });

            //app.MapRazorPages();

            app.Run();

        }
    }

}
