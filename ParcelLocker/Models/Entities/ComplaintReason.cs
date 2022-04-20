using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcelLocker.Models.Entities
{
    [Table("complaint_reasons")]
    public class ComplaintReason
    {
        [Key]
        [Column("complaint_id", Order = 0)]
        public int ComplaintId { get; set; }
        [Key]
        [Column("reason_id", Order = 1)]
        public int ReasonId { get; set; }
        public virtual Complaint Complaint { get; set; }
        public virtual Reason Reason { get; set; }
    }
}
