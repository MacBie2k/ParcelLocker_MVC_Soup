using ParcelLocker.Models.Entities;
using System.Collections.Generic;

namespace ParcelLocker.Models.ViewModels
{
    public class ComplaintVM
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ParcelNumber { get; set; }
        public string Comment { get; set; }
    }
}
