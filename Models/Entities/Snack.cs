using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VendingMachineMVC.Models.Entities.Base;

namespace VendingMachineMVC.Models.Entities
{
    public class Snack : GoodBase
    {
        [Required]
        public string Name { get; set; } = "";

        [Required]
        public DateOnly ExpiryDate { get; set; } = new DateOnly();

        [Column(TypeName = "decimal(18,2)")]
        [Required]
        public decimal Cost { get; set; }
    }
}
