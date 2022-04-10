﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcelLocker.Models.Entities
{
    [Table("complaints")]
    public class Complaint
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("email")]
        public string Email { get; set; }
        [Required]
        [Column("parcel_id")]
        public Parcel Parcel{ get; set; }
        [Column("comment")]
        public string Comment { get; set; }
        [Required]
        [Column("reasons")]
        public ICollection<ComplaintReason> Reasons { get; set; }
    }
}
