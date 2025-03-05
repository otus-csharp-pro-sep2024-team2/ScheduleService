using ScheduleService.Domain.Enums;

namespace ScheduleService.Controllers
{
    public record UpdateEmployeeShiftRequest(int EmployeeId, TimeOnly Start, TimeOnly End);
}