using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomsLibrary.Models;
using RoomsLibrary.Repos;

namespace RoomViewerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomRepository roomRepo;
        public RoomsController(IRoomRepository roomRepository)
        {
            roomRepo = roomRepository;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult> GetAll()
        {
            List<Room> rooms = await roomRepo.GetAllAsync();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<ActionResult> GetOne(string id)
        {
            try
            {
                Room room = await roomRepo.GetByIdAsync(id);
                return Ok(room);
            }
            catch (RoomException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpGet("creator/{userId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<Room>>> GetByCreatorAsync(string userId)
        {
            try
            {
                var rooms = await roomRepo.GetByCreatorAsync(userId);
                return Ok(rooms);
            }
            catch (RoomException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]

        public async Task<ActionResult> Insert([FromBody] Room room)
        {
            try
            {
                await roomRepo.AddAsync(room);
                return Created($"api/rooms/{room.RoomId}", room);
            }

            catch (RoomException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Update(string id, [FromBody] Room room)
        {
            try
            {
                await roomRepo.UpdateAsync(room.RoomId, room);
                return Ok(room);
            }
            catch (RoomException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                await roomRepo.DeleteAsync(id);
                return Ok("Room deleted successfully");
            }
            catch (RoomException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}