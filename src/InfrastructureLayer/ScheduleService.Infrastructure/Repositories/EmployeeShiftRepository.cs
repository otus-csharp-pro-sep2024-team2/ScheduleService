using ScheduleService.Domain.Entities;
using ScheduleService.Domain.Repositories;
using ScheduleService.Infrastructure.Data;

namespace ScheduleService.Infrastructure.Repositories
{
    public class EmployeeShiftRepository : IEmployeeShiftRepository
    {
        private readonly ScheduleDbContext _context;

        public EmployeeShiftRepository(ScheduleDbContext context)
        {
            _context = context;
        }

        public void Add(EmployeeShift shift)
        {
            _context.EmployeeShifts.Add(shift);
            _context.SaveChanges();
        }

        public EmployeeShift GetById(int id)
        {
            return _context.EmployeeShifts.Find(id);
        }

        public void Update(EmployeeShift shift)
        {
            _context.EmployeeShifts.Update(shift);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var shift = _context.EmployeeShifts.Find(id);
            if (shift != null)
            {
                _context.EmployeeShifts.Remove(shift);
                _context.SaveChanges();
            }
        }

        public IEnumerable<EmployeeShift> GetBySchoolOperatingDayId(int schoolOperatingDayId)
        {
            return _context.EmployeeShifts
                .Where(e => e.SchoolOperatingDayId == schoolOperatingDayId)
                .ToList();
        }
    }
}