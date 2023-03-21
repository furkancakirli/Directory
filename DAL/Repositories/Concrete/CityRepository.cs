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
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(PersonContext dbContext) : base(dbContext)
        {
        }
    }
}
