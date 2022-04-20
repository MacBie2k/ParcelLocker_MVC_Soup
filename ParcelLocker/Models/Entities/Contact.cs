﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcelLocker.Models.Entities
{
    [Table("contacts")]
    public class Contact
    {

            [Key]
            [Column("id")]
            public int Id { get; set; }
            [Required]
            [Column("name")]
            public string Name { get; set; }
            [Required]
            [Column("email")]
            public string Email { get; set; }
            [Required]
            [Column("messsage")]
            public string Message { get; set; }


    }
}
