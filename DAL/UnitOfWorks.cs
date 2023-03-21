using DAL.Repositories.Abstracts;
using DAL.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWorks : IUnitOfWorks
    {
        private static readonly UnitOfWorks lazy = new UnitOfWorks();
        private readonly PersonContext _context;

        public UnitOfWorks()
        {
            _context = new PersonContext();
            PersonRepository = new PersonRepository(_context);
            CityRepository = new CityRepository(_context);
            DistrictRepository = new DistrictRepository(_context);
        }
        public static UnitOfWorks Instance { get { return lazy; } }
        public IPersonRepository PersonRepository { get; private set; }

        public ICityRepository CityRepository { get; private set; }

        public IDistrictRepository DistrictRepository { get; private set; }

        public int Complate()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
