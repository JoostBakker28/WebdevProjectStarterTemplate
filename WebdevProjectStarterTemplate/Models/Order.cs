using System.ComponentModel.DataAnnotations;

namespace WebdevProjectStarterTemplate.Models
{
    public class Order
    {
        [Required]
        public int ProductID { get; set; }
        [Required]
        public int ProductName { get; set; }
        [Required]
        public int ProductPrice { get; set; }
        [Required]
        public int TableID { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public int AmountPaid { get; set; } = 0;
    }
}
