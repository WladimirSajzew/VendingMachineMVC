using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VendingMachineMVC.Models.Entities.Base;

namespace VendingMachineMVC.Models.Entities
{
    public class Snack : GoodBase
    {
        [Required]
        public DateOnly ExpiryDate { get; set; } = new DateOnly();

        public SlotBase? CurrentSlot { get; set; }
    }
}
