using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceStarterCode.Models
{
    public class Property
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        public string Bathrooms { get; set; }
        public string Bedrooms { get; set; }
        public string SquareFeet { get; set; }
    }
}
