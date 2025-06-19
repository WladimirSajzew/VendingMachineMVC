using System.ComponentModel.DataAnnotations;

namespace VendingMachineMVC.Models.Entities.Base
{
    public abstract class SlotBase
    {
        [Required]
        public Guid Id { get; set; }

        public bool IsDisabled { get; set; } = false;
    }
}
