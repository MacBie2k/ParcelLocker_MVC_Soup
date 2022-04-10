using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcelLocker.Models.Entities
{
    [Table("complaint_reasons")]
    public class ComplaintReason
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        public string Name { get; set; }
        [Column("complaints")]
        public ICollection<Complaint> Complaints { get; set; }
    }
}
