using NetCoreWebApiArchitectureDemo.Core.Interfaces;
using NetCoreWebApiArchitectureDemo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreWebApiArchitectureDemo.Domain.Data
{
    public class PartnerRepository : EfRepository<Partner>, IPartnerRepository
    {
        public PartnerRepository(PartnerDbContext dbContext) : base(dbContext)
        {

        }

        // use dbContext directly
        public void GetSomething()
        {
            var allData = this._dbContext.Partners.ToList();
        }
    }
}
