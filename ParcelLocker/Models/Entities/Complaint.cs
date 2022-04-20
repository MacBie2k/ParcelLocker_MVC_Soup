using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcelLocker.Models.Entities
{
    [Table("complaints")]
    public class Complaint
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("id")]
        public int  ComplaintId { get; set; }
        [Required]
        [Column("email")]
        public string Email { get; set; }
        [Required]
        [Column("phone")]
        public string Phone { get; set; }
        [Required]
        [ForeignKey("Parcel")]
        [Column("parcel_number")]
        public string ParcelNumber { get; set; }
        public Parcel Parcel{ get; set; }
        [Column("comment")]
        public string Comment { get; set; }
        public virtual ICollection<ComplaintReason> ComplaintReasons { get; set; }
    }
}
