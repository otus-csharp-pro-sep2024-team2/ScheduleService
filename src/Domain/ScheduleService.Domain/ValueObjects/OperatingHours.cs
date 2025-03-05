using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleService.Domain.ValueObjects
{
    public class WorkingHours: ValueObject
    {
        public int Start { get; }
        public int End { get; }

        public WorkingHours(int start, int end)
        {
            if (end <= start) throw new ArgumentException("End time must be after start time.");
            Start = start;
            End = end;
        }

        public bool OverlapsWith(WorkingHours other)
        {
            return Start < other.End && other.Start < End;
        }
    }
}
