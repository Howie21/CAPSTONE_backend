using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceStarterCode.Models
{
    public class TenantInfo
    {

        [Key]
        public int Id { get; set; }


        [ForeignKey("User")]
        public string TenantId { get; set; }
        public User User { get; set; }


        public string RentDueDate { get; set; }
        public string RentAmount { get; set; }
        public string LicenseNumber { get; set; }
        public int Age { get; set; }

        [ForeignKey("Property")]
        public int PropertyId { get; set; }
        public Property Property { get; set; }

        [ForeignKey("Lease")]
        public int LeaseId { get; set; }
        public Lease Lease { get; set; }

    }
}
