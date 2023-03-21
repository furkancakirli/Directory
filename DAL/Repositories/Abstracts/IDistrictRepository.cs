using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Abstracts
{
    public interface IDistrictRepository:IRepository<District>
    {
        IEnumerable<District> GetByCityId(int cityId);
    }
}
