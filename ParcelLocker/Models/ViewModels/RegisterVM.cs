using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ParcelLocker.Models.ViewModels
{
    public class RegisterVM
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
