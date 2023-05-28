using System.ComponentModel.DataAnnotations;

namespace OnlineHotels.Models
{
    public class Hotel
    {
        [Key]
        public int HId { get; set; }
        [Required]
        public string? HotelName { get; set; }

      
        public   string? City { get; set; }

        public int? Pincode { get; set; }
        public string? Location { get; set; }
        public  string? Facilities { get; set; }


        public IEnumerable<Room>? Rooms { get; set; }

    }
}
