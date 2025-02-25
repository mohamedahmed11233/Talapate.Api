
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Talapate.APi.Helper;
using Talapate.Core.Interfaces;
using Talapate.Repository;
using Talapate.Repository.Data;
using Talapate.Repository.Data.Context;

namespace Talapate.APi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<StoreContext>(opthion =>
             {
                 opthion.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                     });

            builder.Services.AddScoped(typeof(IGenericRepository<>),typeof( GeneraicRepository<>));

            builder.Services.AddAutoMapper(typeof(MappingProfiles));
            //mapping profile ==> AutomMappper

            var app = builder.Build();
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var dbContext = services.GetRequiredService<StoreContext>();
            var LoggerFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {
                await dbContext.Database.MigrateAsync();
                await StoreContextSeed.seedAsync(dbContext);
            }
            catch (Exception ex) 
            {
                var logger = LoggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "an errorr occured during apply the migration");

            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseStaticFiles();
            app.MapControllers();

            app.Run();
        }
    }
}
