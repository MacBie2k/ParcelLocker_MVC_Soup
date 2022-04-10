using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcelLocker.Models.Entities
{
    [Table("parcels")]
    public class Parcel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("parcel_number")]
        public string ParcelNumber { get; set; }
        [Required]
        [Column("pickup_code")]
        public string PickupCode { get; set; }
        [Required]
        [Column("sender_phone")]
        public string SenderPhone { get; set; }
        [Required]
        [Column("sender_email")]
        public string SenderEmail { get; set; }
        [Required]
        [Column("receiver_phone")]
        public string ReceiverPhone { get; set; }
        [Required]
        [Column("receiver_email")]
        public string ReceiverEmail { get; set; }        
        [Required]
        [Column("status")]
        public string Status { get; set; }

        [Required]
        [Column("locker")]
        [ForeignKey("Locker")]
        public string LockerCode{ get; set; }
        public Locker Locker { get; set; }
    }
}
