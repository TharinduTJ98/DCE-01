using System.ComponentModel.DataAnnotations;

namespace Practice01.Models
{
    public class Supplier
    {
        [Key]
        public Guid SupplierId { get; set; }
        [StringLength(50)]
        public string SupplierName { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
