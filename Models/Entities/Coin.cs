using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VendingMachineMVC.Models.Entities.Base;

namespace VendingMachineMVC.Models.Entities
{
    public class Coin : CurrencyBase
    {
        [Required]
        public string Name { get; set; } = "";


        [Column(TypeName = "decimal(18,2)")]
        [Required]
        public decimal Amount { get; set; }
    }
}
