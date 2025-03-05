using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ScheduleService.Infrastructure.Data
{
    public class ScheduleDbContextFactory : IDesignTimeDbContextFactory<ScheduleDbContext>
    {
        public ScheduleDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ScheduleDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=SkiSchoolSchedule;Username=postgres;Password=12345678");

            return new ScheduleDbContext(optionsBuilder.Options);
        }
    }
}