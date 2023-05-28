using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineHotels.Models;
using OnlineHotels.Repository;

namespace OnlineHotels.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRepository _Repository;
        public RoomController(IRepository repository)
        {
            _Repository = repository;
        }
        [HttpGet]

        public IEnumerable<Room>GetAllRomms()
        {
            return _Repository.GetAllRooms();

        }
        [Authorize]
        [HttpPost]
        public ActionResult<Room> AddRooms([FromBody] Room Rooms)
        {
            _Repository.AddRooms(Rooms);
            return Ok(Rooms);
        }

        [HttpGet("{id}")]
        public ActionResult<Room> GetRoomById(int id)
        {
            {
                 var tra = _Repository.GetRoomById(id);
                if (tra == null)
                {
                    return NotFound();
                }
                return tra;
            }
        }
        

        [HttpPut("{id}")]
        public ActionResult<Room>UpdateRooms(int id,Room rooms)
        {
            _Repository.UpdateRooms( id,  rooms);
            return Ok(rooms);
        }
       
        
        [HttpDelete("{id}")]
        public ActionResult<Room> DeleteRooms(int id)
        {
            {
                _Repository.DeleteRooms(id);

                return Ok();
            }
        }
    }
}
