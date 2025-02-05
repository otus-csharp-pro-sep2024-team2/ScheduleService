﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleService.Domain.Entities.Base
{
    public abstract class Entity

    {
        protected Entity(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
