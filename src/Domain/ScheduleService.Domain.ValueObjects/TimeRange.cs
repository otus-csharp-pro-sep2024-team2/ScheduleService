using ScheduleService.Domain.ValueObjects.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleService.Domain.ValueObjects
{
    public class TimeRange : ValueObject
    {
        private TimeOnly _startTime;
        private TimeSpan _duration;
        public TimeRange(TimeOnly startTime, TimeSpan duration)
        {
            _startTime = startTime;
            _duration = duration;
        }
        
        public override bool Equals(IValueObject? other)
        {
            throw new NotImplementedException();
        }
    }
}
