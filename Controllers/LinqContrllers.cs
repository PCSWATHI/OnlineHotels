using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineHotels.Models;

namespace OnlineHotels.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinqContrllers : ControllerBase
    {

        private readonly HotelRoomDbContext _Context;
       
        public LinqContrllers(HotelRoomDbContext Context)
        {
            _Context = Context;
        }
        [HttpGet]
        [Route("Check the Number of hotels available")]


        public ActionResult GetHotelCountByCity(string city)
        {
          
            try
            {
                int hotelCount = _Context.Hotels.Count(hotel => hotel.City == city);
                return Ok(string.Format("The number of hotels in {0} is {1}", city,hotelCount));
            }
            catch(Exception ex)
            {
                return Ok(ex);
            }
           
        }
        [HttpGet("CheckNumberOfRooms")]
        public ActionResult GetNumberOfRoomsInHotel(int Hid)
        {
            try
            {
              int roomCount = _Context.Rooms.Count(room => room.HId == Hid);
                return Ok(string.Format("the number of rooms in Hotel is {0}", roomCount));
            }
            catch (Exception)
            {
                return Ok(String.Format("The number of rooms in {0} is 0", Hid));
            }
        }
       
        [Route("Find the Rooms  with in range")]
        [HttpGet]
        public ActionResult GetRoomsByPrice(int MinimumPrice, int MaximumPrice)
        {
            try
            {
               
                var rooms = from room in _Context.Rooms
                            join hotels in _Context.Hotels on room.HId equals hotels.HId
                            where room.Price >= MinimumPrice && room.Price <= MaximumPrice
                            select new
                            {
                                room.RId,
                                 room.Price,
                                hotels.HotelName,
                                hotels.City,
                                hotels.Location
                            };
                var result = rooms.ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Find the Count of rooms in a floor ")]
        public ActionResult GetNumberOfRoomsInaFloor(string HotelName, int FloorNumber)
        {
            try
            {
                var roomCount = _Context.Rooms
                    .Count(room => room.Hotels.HotelName == HotelName && room.FloorNumber == FloorNumber);

                return Ok(string.Format("the numbers of rooms in a hotel {0} are {1}",HotelName,roomCount));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}