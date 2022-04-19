using System.ComponentModel.DataAnnotations;

namespace ParcelLocker.Models.ViewModels
{
    public class LogInVM
    {
        [Required]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
