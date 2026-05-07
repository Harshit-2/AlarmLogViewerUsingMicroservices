using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RoomsLibrary.Models
{
    [Table("Rooms")]
    public class Room
    {
        [Key]
        [Column(TypeName = "CHAR(6)")]
        public string RoomId { get; set; }

        [Column(TypeName = "VARCHAR(30)")]
        public string RoomName { get; set; }

        public int MinTemp { get; set; }
        public int MaxTemp { get; set; }

        [Column(TypeName = "CHAR(6)")]
        public string CreatedBy { get; set; } // UserId reference

        [Column(TypeName = "VARCHAR(30)")]
        public string CreatedAt { get; set; }
    }
}
