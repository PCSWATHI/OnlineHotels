using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace OnlineHotels.Models
{
  
    public class HotelRoomDbContext : DbContext
    {
       
        public HotelRoomDbContext(DbContextOptions<HotelRoomDbContext> options) : base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }

   
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>()
                .HasOne(b => b.Hotels)
                .WithMany(a => a.Rooms)
                .HasForeignKey(p => p.HId);
        }
    }
}
