using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcelLocker.Models.Entities
{
    [Table("lockers")]
    public class Locker
    {

        [Column("id")]
        public int Id { get; set; }
        [Key]
        [Column("code")]
        public string Code { get; set; }
        [Required]
        [Column("city")]
        public string City { get; set; }
        [Required]
        [Column("street")]
        public string Street { get; set; }
        public ICollection<Parcel> Parcels { get; set; }
    }
}
