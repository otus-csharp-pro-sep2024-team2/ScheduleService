using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleService.Domain.ValueObjects.Base
{
    public abstract class ValueObject : IValueObject
    {
        public abstract bool Equals(IValueObject? other);
    }
}
