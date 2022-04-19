using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ParcelLocker.Models.Entities
{
    public class Courier : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
