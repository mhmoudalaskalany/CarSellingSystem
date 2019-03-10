
using System.ComponentModel.DataAnnotations;

namespace CarSellingSystem.Models.OwnedTypes
{
    public class Contact
    {
        [Required]
        [StringLength(255)]
        public string ContactName { get; set; }
        [StringLength(255)]
        public string ContactEmail { get; set; }
        [Required]
        [StringLength(255)]
        public string ContactPhone { get; set; }
    }
}
