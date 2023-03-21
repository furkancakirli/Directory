using DAL.Repositories.Abstracts;
using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Concrete
{
    public class DistrictRepository : Repository<District>, IDistrictRepository
    {
        public DistrictRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<District> GetByCityId(int cityId)
        {
            return PersonelContext.Districts.Where(p=>p.CityId == cityId);
        }

        public PersonContext PersonelContext { get { return _dbContext as PersonContext; } }
    }
}
