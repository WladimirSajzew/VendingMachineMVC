using System.ComponentModel.DataAnnotations;

namespace VendingMachineMVC.Models.Entities.Base
{
    public abstract class GoodBase
    {
        [Required]
        public Guid Id { get; set; }

        public bool IsDisabled { get; set; } = false;
    }
}
