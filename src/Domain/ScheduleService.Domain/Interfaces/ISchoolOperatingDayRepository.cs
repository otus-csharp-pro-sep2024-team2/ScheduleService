using ScheduleService.Domain.Entities;

namespace ScheduleService.Domain.Repositories
{
    public interface ISchoolOperatingDayRepository
    {
        void Add(SchoolOperatingDay day);
        SchoolOperatingDay GetById(int id);
        void Update(SchoolOperatingDay day);
        void Remove(int id);
    }
}