using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcelLocker.Models.Entities
{
    [Table("reasons")]
    public class Reason
    {
        [Key]
        [Column("id")]
        public int ReasonId { get; set; }
        [Required]
        [Column("name")]
        public string Name { get; set; }
        public virtual ICollection<ComplaintReason> ComplaintReasons { get; set; }
    }
}
