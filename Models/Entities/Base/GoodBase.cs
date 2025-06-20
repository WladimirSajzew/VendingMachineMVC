using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendingMachineMVC.Models.Entities.Base
{
    public abstract class GoodBase
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = "";

        [Column(TypeName = "decimal(18,2)")]
        [Required]
        public decimal Cost { get; set; }

        public bool IsDisabled { get; set; } = false;
    }
}
