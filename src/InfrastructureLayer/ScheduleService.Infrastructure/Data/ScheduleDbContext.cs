using Microsoft.EntityFrameworkCore;
using ScheduleService.Domain.Entities;

namespace ScheduleService.Infrastructure.Data
{
    public class ScheduleDbContext : DbContext
    {
        public DbSet<SchoolOperatingDay> SchoolOperatingDays { get; set; }
        public DbSet<EmployeeShift> EmployeeShifts { get; set; }

        public ScheduleDbContext(DbContextOptions<ScheduleDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SchoolOperatingDay>(entity =>
            {
                entity.ToTable("SchoolOperatingDays");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .UseIdentityColumn();
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.DayType).IsRequired();
                entity.Property(e => e.Start).IsRequired();
                entity.Property(e => e.End).IsRequired();
            });

            modelBuilder.Entity<EmployeeShift>(entity =>
            {
                entity.ToTable("EmployeeShifts");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .UseIdentityColumn();
                entity.Property(e => e.EmployeeId).IsRequired();
                entity.Property(e => e.SchoolOperatingDayId).IsRequired();
                entity.Property(e => e.Start).IsRequired();
                entity.Property(e => e.End).IsRequired();

                // Связь с SchoolOperatingDay (один ко многим)
                entity.HasOne(e => e.SchoolOperatingDay)
                    .WithMany() // SchoolOperatingDay не имеет коллекции EmployeeShifts (пока)
                    .HasForeignKey(e => e.SchoolOperatingDayId)
                    .IsRequired();
            });
        }
    }
}