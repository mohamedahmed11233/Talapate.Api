
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;
using Talapate.APi.Error;
using Talapate.APi.Helper;
using Talapate.APi.Middleware;
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

            #region DI
            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<StoreContext>(opthion =>
             {
                 opthion.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
             });

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GeneraicRepository<>));

            builder.Services.AddAutoMapper(typeof(MappingProfiles));

            builder.Services.Configure<ApiBehaviorOptions>(opthion =>
            {
                opthion.InvalidModelStateResponseFactory = (actionContext) =>
                {
                    var errors = actionContext.ModelState.Where(o => o.Value.Errors.Count() > 0)
                                                         .SelectMany(o => o.Value.Errors)
                                                         .Select(e => e.ErrorMessage)
                                                         .ToList();


                    var response = new ApiValidathionErrorr()
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(response);
                };
            });

            #endregion
            //mapping profile ==> AutomMappper

            var app = builder.Build();
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var dbContext = services.GetRequiredService<StoreContext>();
            var LoggerFactory = services.GetRequiredService<ILoggerFactory>();

            #region Update DataBase
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

            #endregion

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseStaticFiles();
            app.MapControllers();

            app.Run();
        }
    }
}
