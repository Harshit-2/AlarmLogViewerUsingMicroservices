using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RoomsLibrary.Models;
using UserLibrary.Repos;

namespace RoomsLibrary.Repos
{
    public class EFRoomRepository : IRoomRepository
    {
        RoomDbContext context = new RoomDbContext();

        public async Task AddAsync(Room room)
        {
            try
            {
                await context.Rooms.AddAsync(room);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new RoomException(ex.Message);
            }
        }

        public async Task<List<Room>> GetAllAsync()
        {
            return await context.Rooms.ToListAsync();
        }

        public async Task<Room> GetByIdAsync(string id)
        {
            Room room = await context.Rooms.FirstOrDefaultAsync(r => r.RoomId == id);

            if (room == null)
            {
                throw new RoomException("No such room");
            }
            return room;
        }

        public async Task<List<Room>> GetByCreatorAsync(string userId)
        {
            var rooms = await context.Rooms
                .Where(r => r.CreatedBy == userId)
                .ToListAsync();

            if (rooms.Count == 0)
            {
                throw new RoomException("No rooms found");
            }

            return rooms;
        }

        public async Task UpdateAsync(string id, Room room)
        {
            try
            {
                var existingRoom = await context.Rooms.FirstOrDefaultAsync(r => r.RoomId == id);

                if (existingRoom == null)
                {
                    throw new RoomException("Room not found");
                }
                //existingRoom.RoomId = room.RoomId;
                existingRoom.RoomName = room.RoomName;
                existingRoom.MinTemp = room.MinTemp;
                existingRoom.MaxTemp = room.MaxTemp;
                existingRoom.CreatedBy = room.CreatedBy;
                existingRoom.CreatedAt = room.CreatedAt;

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new RoomException(ex.Message);
            }
        }

        public async Task DeleteAsync(string id)
        {
            var roomToDel = await GetByIdAsync(id);
            try
            {
                context.Rooms.Remove(roomToDel);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new RoomException(ex.Message);
            }
        }
    }
}