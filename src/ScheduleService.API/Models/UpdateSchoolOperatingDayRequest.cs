using ScheduleService.Domain.Enums;

namespace ScheduleService.Controllers
{
    public record UpdateSchoolOperatingDayRequest(DateOnly Date, DayType DayType, TimeOnly Start, TimeOnly End);
}