using System.ComponentModel.DataAnnotations;

namespace LibraryServices.Data.Models
{
    public class Cost
    {
        [Key] public int CostId { get; set; }

        public double Price { get; set; }
        public bool DiscountCode { get; set; }
    }
}
