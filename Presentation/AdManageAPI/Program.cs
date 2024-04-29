
using AdManage.Application.Features.CQRS.Handlers;
using AdManage.Application.Interfaces;
using AdManage.Persistence.DbContexts;
using AdManage.Persistence.Repositories;

namespace AdManageAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();


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

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
