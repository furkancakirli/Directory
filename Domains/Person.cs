using System.ComponentModel.DataAnnotations.Schema;

namespace Domains
{
    public class Person:BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string PhoneNumber { get; set;}
        public int CityId { get; set; }
        public int DistrictId { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        [ForeignKey("DistrictId")]
        public virtual District District { get; set; }


    }
}