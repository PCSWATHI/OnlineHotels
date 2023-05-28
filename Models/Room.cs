using System.ComponentModel.DataAnnotations;

namespace OnlineHotels.Models
{
    public class Room
    {
        [Key]
        public int? RId { get; set; }

        public int? RoomNumber { get; set; }

        public string? RoomType { get; set; }

        public string? Description { get; set; }
        
        public string? Amenities { get; set; }

        public string? Availability { get; set; }

        public int? Price { get; set; }

        public int? FloorNumber { get; set; }

        public int? HId { get; set; }
        public Hotel? Hotels { get; set; }
      
    }
}
