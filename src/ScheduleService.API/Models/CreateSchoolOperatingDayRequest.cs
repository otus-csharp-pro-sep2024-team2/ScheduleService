using ScheduleService.Domain.Enums;

namespace ScheduleService.Controllers
{
    public record CreateSchoolOperatingDayRequest(DateOnly Date, DayType DayType, TimeOnly Start, TimeOnly End);
}