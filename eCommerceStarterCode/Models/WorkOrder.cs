using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace eCommerceStarterCode.Models

{
    public class WorkOrder
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey("User")]
        public string RequestorId { get; set; }
        public User User { get; set; }

        [ForeignKey("Property")]

        public int PropertyId { get; set; }
        public Property Property { get; set; }


        public string OrderChar { get; set; }

        public bool forLandlord { get; set; }
        public string ActiveStatus { get; set; }

    }
}
