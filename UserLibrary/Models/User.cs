using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UserLibrary.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [Column(TypeName = "CHAR(6)")]
        public string UserId { get; set; }

        [Column(TypeName = "VARCHAR(30)")]
        public string Username { get; set; }

        [Column(TypeName = "VARCHAR(30)")]
        public string Password { get; set; }

        [Column(TypeName = "VARCHAR(30)")]
        public string Role { get; set; }

        [Column(TypeName = "VARCHAR(30)")]
        public string CreatedAt { get; set; }
    }
}
