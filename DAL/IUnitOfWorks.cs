using DAL.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUnitOfWorks:IDisposable
    {
         IPersonRepository PersonRepository { get; }
         ICityRepository CityRepository { get; }  
         IDistrictRepository DistrictRepository { get; }
         int Complate();
    }
}
