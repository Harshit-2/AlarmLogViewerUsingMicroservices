using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace RoomsLibrary.Models
{
    public class RoomDbContext: DbContext
    {
        public RoomDbContext()
        {
        }

        public RoomDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Room> Rooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LTIN732805\\SQLEXPRESS;Database=PrjRoomsLogDB;Trusted_connection=true;TrustServerCertificate=true;");
        }
    }
}
