using ScheduleService.Domain.Enums;

namespace ScheduleService.Domain.Entities
{
    public class EmployeeShift : Entity
    {
        public int Id { get; private set; }
        public int EmployeeId { get; private set; } // Идентификатор сотрудника
        public int SchoolOperatingDayId { get; private set; } // Внешний ключ
        public TimeOnly Start { get; private set; }
        public TimeOnly End { get; private set; }
        public SchoolOperatingDay SchoolOperatingDay { get; private set; } // Навигационное свойство

        public EmployeeShift(int employeeId, int schoolOperatingDayId, TimeOnly start, TimeOnly end)
        {
            EmployeeId = employeeId;
            SchoolOperatingDayId = schoolOperatingDayId;
            Start = start;
            End = end;
            if (End <= Start) throw new ArgumentException("End time must be after start time.");
        }

        // Метод для проверки, вписывается ли смена в рабочий день
        public bool IsWithinOperatingDay(TimeOnly operatingDayStart, TimeOnly operatingDayEnd)
        {
            return Start >= operatingDayStart && End <= operatingDayEnd;
        }
    }
}