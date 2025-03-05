using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleService.Domain.Enums
{

    public enum DayType
    {
        /// <summary>
        /// Будний день
        /// </summary>
        Weekday = 0,
        
        /// <summary>
        /// Выходной день
        /// </summary>
        Weekend = 1,
        
        /// <summary>
        /// Праздничный день
        /// </summary>
        Holiday = 2 
    }
}
