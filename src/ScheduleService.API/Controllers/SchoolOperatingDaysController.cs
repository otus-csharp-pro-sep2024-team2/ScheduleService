using Microsoft.AspNetCore.Mvc;
using ScheduleService.Application.Services;
using ScheduleService.Domain.Entities;
using ScheduleService.Domain.Enums;

namespace ScheduleService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchoolOperatingDaysController : ControllerBase
    {
        private readonly ApplicationService _applicationService;

        public SchoolOperatingDaysController(ApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost]
        public IActionResult CreateSchoolOperatingDay([FromBody] CreateSchoolOperatingDayRequest request)
        {
            _applicationService.AddSchoolOperatingDay(request.Date, request.DayType, request.Start, request.End);
            return Ok(new { Message = "School operating day created." });
        }

        [HttpGet("{id}")]
        public IActionResult GetSchoolOperatingDay(int id)
        {
            var day = _applicationService.GetSchoolOperatingDay(id);
            if (day == null) return NotFound();
            return Ok(day);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSchoolOperatingDay(int id, [FromBody] UpdateSchoolOperatingDayRequest request)
        {
            var day = _applicationService.GetSchoolOperatingDay(id);
            if (day == null) return NotFound();

            day = new SchoolOperatingDay(request.Date, request.DayType, request.Start, request.End);
            _applicationService.UpdateSchoolOperatingDay(day);
            return Ok(new { Message = "School operating day updated." });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSchoolOperatingDay(int id)
        {
            _applicationService.RemoveSchoolOperatingDay(id);
            return Ok(new { Message = "School operating day deleted." });
        }

        [HttpPost("{schoolOperatingDayId}/employee-shifts")]
        public IActionResult CreateEmployeeShift(int schoolOperatingDayId, [FromBody] CreateEmployeeShiftRequest request)
        {
            _applicationService.AddEmployeeShift(request.EmployeeId, schoolOperatingDayId, request.Start, request.End);
            return Ok(new { Message = "Employee shift created." });
        }

        [HttpGet("{schoolOperatingDayId}/employee-shifts")]
        public IActionResult GetEmployeeShifts(int schoolOperatingDayId)
        {
            var shifts = _applicationService.GetEmployeeShiftsBySchoolOperatingDay(schoolOperatingDayId);
            return Ok(shifts);
        }

        [HttpGet("employee-shifts/{id}")]
        public IActionResult GetEmployeeShift(int id)
        {
            var shift = _applicationService.GetEmployeeShift(id);
            if (shift == null) return NotFound();
            return Ok(shift);
        }

        [HttpPut("employee-shifts/{id}")]
        public IActionResult UpdateEmployeeShift(int id, [FromBody] UpdateEmployeeShiftRequest request)
        {
            var shift = _applicationService.GetEmployeeShift(id);
            if (shift == null) return NotFound();

            shift = new EmployeeShift(request.EmployeeId, shift.SchoolOperatingDayId, request.Start, request.End);
            _applicationService.UpdateEmployeeShift(shift);
            return Ok(new { Message = "Employee shift updated." });
        }

        [HttpDelete("employee-shifts/{id}")]
        public IActionResult DeleteEmployeeShift(int id)
        {
            _applicationService.RemoveEmployeeShift(id);
            return Ok(new { Message = "Employee shift deleted." });
        }
    }
}