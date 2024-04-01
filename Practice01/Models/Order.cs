using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice01.Models
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        [Range(1,1)]
        public int OrderStatus { get; set; }
        [Range(1, 1)]
        public int OrderType { get; set; }
        public Guid OrderBy { get; set; }
        public DateTime OrderedOn { get; set; }
        public DateTime ShippedOn { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        /*[ForeignKey("OrderBy")]
        public virtual User User { get; set; }
        */
    }

    
}
