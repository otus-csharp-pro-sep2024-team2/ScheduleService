using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ScheduleService.Application.Services;
using ScheduleService.Infrastructure.Data;
using ScheduleService.Infrastructure.Repositories;
using ScheduleService.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace ScheduleService.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Schedule Service API", Version = "v1" });
            });

            // Set connection string to database
            builder.Services.AddDbContext<ScheduleDbContext>(options =>
            {
                options.UseNpgsql("Host=localhost;Port=5432;Database=SkiSchoolSchedule;Username=postgres;Password=12345678");
            });


            // Register the repository and application service
            builder.Services.AddScoped<ISchoolOperatingDayRepository, SchoolOperatingDayRepository>();
            builder.Services.AddScoped<IEmployeeShiftRepository, EmployeeShiftRepository>();
            builder.Services.AddScoped<ApplicationService>();

            // Configure Web API
            builder.Services.AddControllers();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Schedule Service API v1"));
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
