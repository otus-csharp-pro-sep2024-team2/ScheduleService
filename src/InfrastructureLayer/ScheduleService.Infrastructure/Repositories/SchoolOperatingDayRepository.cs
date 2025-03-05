using ScheduleService.Domain.Entities;
using ScheduleService.Domain.Repositories;
using ScheduleService.Infrastructure.Data;

namespace ScheduleService.Infrastructure.Repositories
{
    public class SchoolOperatingDayRepository : ISchoolOperatingDayRepository
    {
        private readonly ScheduleDbContext _context;

        public SchoolOperatingDayRepository(ScheduleDbContext context)
        {
            _context = context;
        }

        public void Add(SchoolOperatingDay day)
        {
            _context.SchoolOperatingDays.Add(day);
            _context.SaveChanges();
        }

        public SchoolOperatingDay GetById(int id)
        {
            return _context.SchoolOperatingDays.Find(id);
        }

        public void Update(SchoolOperatingDay day)
        {
            _context.SchoolOperatingDays.Update(day);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var day = _context.SchoolOperatingDays.Find(id);
            if (day != null)
            {
                _context.SchoolOperatingDays.Remove(day);
                _context.SaveChanges();
            }
        }
    }
}