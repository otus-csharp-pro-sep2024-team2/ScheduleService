using ScheduleService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleService.Domain.Entities.Base
{
    public class Person : Entity
    {
        
        public Person(int id, FullName fullName) : base(id)
        {
            FullName = fullName;
        }

        public FullName FullName { get; set; }
    }
}
