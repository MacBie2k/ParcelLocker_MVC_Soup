using System.ComponentModel.DataAnnotations;

namespace ParcelLocker.Models.ViewModels
{
    public class ContactVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
