using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RoomsLibrary.Models
{
    public class Alert
    {
        [Column(TypeName = "CHAR(6)")]
        public string RoomId { get; set; }

    }
}
