﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Landeeyo.Pizza.Common.Models.AccountControl
{
    /// <summary>
    /// User model
    /// </summary>
    [Table("User")]
    public class User : ISoftDeletingEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        [MaxLength(25), MinLength(7)]
        public string Password { get; set; }

        [Required]
        [MaxLength(25), MinLength(3)]
        public string Firstname { get; set; }

        [Required]
        [MaxLength(25), MinLength(3)]
        public string Surname { get; set; }

        [Required]
        [MaxLength(25), MinLength(5)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? CreateDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeactivationDate { get; set; }
    }
}
