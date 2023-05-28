using OnlineHotels.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using System.Diagnostics;
namespace OnlineHotels.Repository
{
    public interface IRepository
    {
        void AddHotels(Hotel Hotels);

        IEnumerable<Hotel> GetAll();
      

        Hotel GetById(int id);

        void UpdateHotels(int id  ,Hotel hotel);


        void DeleteHotel(int id);
        public void AddRooms(Room Rooms);
        public IEnumerable<Room> GetAllRooms();
        public Room GetRoomById(int id);
        public void UpdateRooms(int id ,Room rooms);
        void DeleteRooms(int id);








    }
}
