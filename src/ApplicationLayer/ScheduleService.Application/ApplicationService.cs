using ScheduleService.Domain.Entities;
using ScheduleService.Domain.Repositories;
using ScheduleService.Domain.Enums;

namespace ScheduleService.Application.Services
{
    public class ApplicationService
    {
        private readonly ISchoolOperatingDayRepository _schoolOperatingDayRepository;
        private readonly IEmployeeShiftRepository _employeeShiftRepository;

        public ApplicationService(
            ISchoolOperatingDayRepository schoolOperatingDayRepository,
            IEmployeeShiftRepository employeeShiftRepository)
        {
            _schoolOperatingDayRepository = schoolOperatingDayRepository;
            _employeeShiftRepository = employeeShiftRepository;
        }

        public void AddSchoolOperatingDay(DateOnly date, DayType dayType, TimeOnly start, TimeOnly end)
        {
            var day = new SchoolOperatingDay(date, dayType, start, end);
            _schoolOperatingDayRepository.Add(day);
        }

        public SchoolOperatingDay GetSchoolOperatingDay(int id)
        {
            return _schoolOperatingDayRepository.GetById(id);
        }

        public void UpdateSchoolOperatingDay(SchoolOperatingDay day)
        {
            _schoolOperatingDayRepository.Update(day);
        }

        public void RemoveSchoolOperatingDay(int id)
        {
            _schoolOperatingDayRepository.Remove(id);
        }

        public void AddEmployeeShift(int employeeId, int schoolOperatingDayId, TimeOnly start, TimeOnly end)
        {
            var schoolOperatingDay = _schoolOperatingDayRepository.GetById(schoolOperatingDayId);
            if (schoolOperatingDay == null)
                throw new ArgumentException("School operating day not found.");

            var shift = new EmployeeShift(employeeId, schoolOperatingDayId, start, end);
            if (!shift.IsWithinOperatingDay(schoolOperatingDay.Start, schoolOperatingDay.End))
                throw new InvalidOperationException("Shift time is outside operating day bounds.");

            _employeeShiftRepository.Add(shift);
        }

        public EmployeeShift GetEmployeeShift(int id)
        {
            return _employeeShiftRepository.GetById(id);
        }

        public IEnumerable<EmployeeShift> GetEmployeeShiftsBySchoolOperatingDay(int schoolOperatingDayId)
        {
            return _employeeShiftRepository.GetBySchoolOperatingDayId(schoolOperatingDayId);
        }

        public void UpdateEmployeeShift(EmployeeShift shift)
        {
            _employeeShiftRepository.Update(shift);
        }

        public void RemoveEmployeeShift(int id)
        {
            _employeeShiftRepository.Remove(id);
        }
    }
}