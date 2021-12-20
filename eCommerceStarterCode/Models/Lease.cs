using System.ComponentModel.DataAnnotations;

namespace eCommerceStarterCode.Models
{
    public class Lease
    {
        [Key]
        public int Id { get; set; }

        public string LeaseNumber { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string SafetyDeposit { get; set; }

    }
}
