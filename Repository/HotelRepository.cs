using Microsoft.EntityFrameworkCore;
using OnlineHotels.Models;
using System.Diagnostics;

namespace OnlineHotels.Repository
{
    public class HotelRepository : IRepository
    {
        private readonly HotelRoomDbContext _dbContext;
        public HotelRepository(HotelRoomDbContext db)
        {
            _dbContext = db;
        }

        public void AddHotels(Hotel Hotel)
        {

            _dbContext.Hotels.Add(Hotel);
            _dbContext.SaveChanges();


        }
        public IEnumerable<Hotel> GetAll()
        {
            return _dbContext.Hotels.ToList();
        }

        public Hotel GetById(int id)
        {
            var Hotels = _dbContext.Hotels.FirstOrDefault(p => p.HId == id);
            return Hotels;

        }

      
        public void UpdateHotels(int id, Hotel hotels)
        {
            var res = _dbContext.Hotels.Find(id);
            res.HotelName = hotels.HotelName;
            res.Pincode = hotels.Pincode;
            res.City = hotels.City;
            res.Location= hotels.Location;
            res.Facilities = hotels.Facilities;
          


            _dbContext.Hotels.Update(res);
            _dbContext.SaveChanges();

        }


        public void DeleteHotel(int id)

        {
            var hotel = _dbContext.Hotels.Find(id);

            if (hotel != null)
            {
                var rooms = _dbContext.Rooms.Where(room => room.HId == id);
                _dbContext.Rooms.RemoveRange(rooms);

           
                _dbContext.Hotels.Remove(hotel);
                _dbContext.SaveChanges();
            }
        }
        public void AddRooms(Room Rooms)
        {

            _dbContext.Rooms.Add(Rooms);
            _dbContext.SaveChanges();


        }
        public IEnumerable<Room> GetAllRooms()
        {
            return _dbContext.Rooms.ToList();
        }

        public Room GetRoomById(int id)
        {
            var Rooms = _dbContext.Rooms.FirstOrDefault(p => p.RId == id);
            return Rooms;

        }
        public void UpdateRooms(int id, Room rooms)
        {
            var res = _dbContext.Rooms.Find(id);
            res.FloorNumber = rooms.FloorNumber;
            res.Availability = rooms.Availability;
            res.Price = rooms.Price;
            res.Amenities = rooms.Amenities;
            res.HId = rooms.HId;
            res.Description = rooms.Description;
            res.RoomType= rooms.RoomType;


            _dbContext.Rooms.Update(res);
            _dbContext.SaveChanges();

        }
        public void DeleteRooms(int id)
        {
            var Ph = _dbContext.Rooms.Find(id);
            _dbContext.Rooms.Remove(Ph);
            _dbContext.SaveChanges();
        }



    }
}

