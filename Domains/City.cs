using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public  class City :BaseEntity
    {

        public City() {
            //Districts = new List<District>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

       // public virtual ICollection<District> Districts { get; set; }
    }
}
