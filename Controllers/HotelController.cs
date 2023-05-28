using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using OnlineHotels.Models;
using OnlineHotels.Repository;
using System.Collections;
using System.Diagnostics;

namespace OnlineHotels.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IRepository _Repository;
        public HotelController(IRepository repository)
        {
            _Repository = repository;
        }
        [HttpGet]

        public IEnumerable<Hotel> GetAll()
        {
            return _Repository.GetAll();

        }
        [Authorize]
        [HttpPost]
        public ActionResult<Hotel> AddHotels([FromBody] Hotel hotel)
        {
            _Repository.AddHotels(hotel);
            return Ok(hotel);
        }

        [HttpGet("{id}")]
      
        public ActionResult<Hotel> GetById(int id)
        {

            var Hotel = _Repository.GetById(id);
          
            if (Hotel == null)
            {
                return NotFound();
            }

            return Hotel;
        }


        [Authorize]
        [HttpPut("{id}")]
        public ActionResult<Hotel>UpdateHotels(int id,Hotel hotel)
        {
            _Repository.UpdateHotels(id,hotel);
            return Ok(hotel);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult<Hotel>DeleteHotel(int id)
        {
            {
                _Repository.DeleteHotel(id);

                return Ok();
            }
        }
    }
}
