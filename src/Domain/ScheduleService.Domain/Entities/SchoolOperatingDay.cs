using ScheduleService.Domain.ValueObjects;
using ScheduleService.Domain.Enums;

namespace ScheduleService.Domain.Entities
{
    public class SchoolOperatingDay : Entity
    {
        public int Id { get; private set; }
        public DateOnly Date { get; private set; }
        public DayType DayType { get; private set; }
        public TimeOnly Start { get; private set; }
        public TimeOnly End { get; private set; }

        public SchoolOperatingDay( DateOnly date, DayType dayType, TimeOnly start, TimeOnly end)
        {
            Date = date;    
            DayType = dayType;
            Start = start;
            End = end;
            if (End <= Start) throw new ArgumentException("End time must be after start time.");
        }

        
        public int GetMaxBreaks()
        {
            return DayType == DayType.Holiday ? 2 : 3;
        }
    }
}