using System.ComponentModel.DataAnnotations;

namespace VendingMachineMVC.Models.Entities.Base
{
    public abstract class SlotBase
    {
        [Required]
        public Guid Id { get; set; }

        public int Positions { get; set; } = 0;

        public bool IsDisabled { get; set; } = false;
    }
}
