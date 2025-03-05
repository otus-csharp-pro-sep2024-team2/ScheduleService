using ScheduleService.Domain.Enums;

namespace ScheduleService.Controllers
{
    public record CreateEmployeeShiftRequest(int EmployeeId, TimeOnly Start, TimeOnly End);
}