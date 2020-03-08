using NetCoreWebApiArchitectureDemo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreWebApiArchitectureDemo.Domain.Entities
{
    public class Partner : BaseEntity
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Description { get; set; }
    }
}
