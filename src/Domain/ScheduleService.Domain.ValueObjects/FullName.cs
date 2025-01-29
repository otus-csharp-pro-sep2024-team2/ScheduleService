using ScheduleService.Domain.ValueObjects.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleService.Domain.ValueObjects
{
    public class FullName : ValueObject
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string? Patronymic { get; }

        public FullName(string firstName, string lastName, string? patronymic = null)
        {
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
        }

        public override bool Equals(IValueObject? other)
        {
            throw new NotImplementedException();
        }
    }
}
