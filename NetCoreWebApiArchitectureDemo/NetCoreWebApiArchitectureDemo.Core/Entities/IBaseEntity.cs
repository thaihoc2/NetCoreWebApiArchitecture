using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreWebApiArchitectureDemo.Core.Entities
{
    public abstract class IBaseEntity
    {
        public int Id { get; set; }
    }
}
