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
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(PersonContext dbContext) : base(dbContext)
        {
        }
    }
}
