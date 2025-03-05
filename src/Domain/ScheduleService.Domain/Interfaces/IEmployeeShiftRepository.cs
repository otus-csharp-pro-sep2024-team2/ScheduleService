using ScheduleService.Domain.Entities;

namespace ScheduleService.Domain.Repositories
{
    public interface IEmployeeShiftRepository
    {
        void Add(EmployeeShift shift);
        EmployeeShift GetById(int id);
        void Update(EmployeeShift shift);
        void Remove(int id);
        IEnumerable<EmployeeShift> GetBySchoolOperatingDayId(int schoolOperatingDayId); // Для получения смен по дню
    }
}