using System.ComponentModel.DataAnnotations;

namespace eCommerceStarterCode.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        public string BuildingNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
