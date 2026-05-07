using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AlertsLibrary.Models
{
    [Table("Alerts")]
    public class Alert
    {
        [Key]
        [Column(TypeName = "CHAR(6)")]
        public string AlertId { get; set; }

        [Column(TypeName = "CHAR(6)")]
        public string RoomId { get; set; }

        public decimal Temperature { get; set; }

        [Column(TypeName = "VARCHAR(30)")]
        public string Status { get; set; }

        [Column(TypeName = "VARCHAR(30)")]
        public string AlertTime { get; set; }
    }
}
