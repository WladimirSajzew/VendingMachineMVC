using System.ComponentModel.DataAnnotations;
using VendingMachineMVC.Models.Entities.Base;

namespace VendingMachineMVC.Models.Entities
{
    public class Spiral : SlotBase
    {
        [Required]
        public int Position { get; set; } = 0;
        
        public GoodBase? CurrentGood { get; set; }
    }
}
