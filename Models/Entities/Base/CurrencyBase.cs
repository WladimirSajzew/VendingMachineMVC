using System.ComponentModel.DataAnnotations;

namespace VendingMachineMVC.Models.Entities.Base
{
    public abstract class CurrencyBase
    {
        [Required]
        public Guid Id { get; set; }

        public bool IsDisabled { get; set; } = false;
    }
}
