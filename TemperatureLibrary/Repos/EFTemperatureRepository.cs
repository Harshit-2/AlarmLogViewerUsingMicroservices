using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TemperatureLibrary.Models;

namespace TemperatureLibrary.Repos
    {
    public class EFTemperatureRepository : ITemperatureRepository
    {
        TemperatureDbContext context = new TemperatureDbContext();

        public async Task AddAsync(Temperature temperature)
        {
            try
            {
                await context.Temperature.AddAsync(temperature);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new TemperatureException(ex.Message);
            }
        }

        public async Task<Temperature> GetByIdAsync(string id)
        {
            try
            {
                var temp = await context.Temperature
                    .FirstOrDefaultAsync(t => t.ReadingId == id);

                if (temp == null)
                {
                    throw new TemperatureException("Temperature record not found");
                }

                return temp;
            }
            catch (Exception ex)
            {
                throw new TemperatureException(ex.Message);
            }
        }

        public async Task<Temperature> GetByRoomIdAsync(string roomId)
        {
            try
            {
                var temp = await context.Temperature
                    .FirstOrDefaultAsync(t => t.RoomId == roomId);

                if (temp == null)
                {
                    throw new TemperatureException("No temperature found for this room");
                }

                return temp;
            }
            catch (Exception ex)
            {
                throw new TemperatureException(ex.Message);
            }
        }

        public async Task<Temperature> GetLatestByRoomIdAsync(string roomId)
        {
            try
            {
                var temp = await context.Temperature
                    .Where(t => t.RoomId == roomId)
                    .OrderByDescending(t => t.RecordedAt)
                    .FirstOrDefaultAsync();

                if (temp == null)
                {
                    throw new TemperatureException("No temperature records found");
                }
                return temp;
            }
            catch (Exception ex)
            {
                throw new TemperatureException(ex.Message);
            }
        }

        public async Task UpdateAsync(string id, Temperature temperature)
        {
            try
            {
                var existingTemp = await context.Temperature
                    .FirstOrDefaultAsync(t => t.ReadingId == id);

                if (existingTemp == null)
                {
                    throw new TemperatureException("Temperature record not found");
                }
                existingTemp.RoomId = temperature.RoomId;
                existingTemp.TemperatureValue = temperature.TemperatureValue;
                existingTemp.RecordedAt = temperature.RecordedAt;
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new TemperatureException(ex.Message);
            }
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                var temp = await context.Temperature
                    .FirstOrDefaultAsync(t => t.ReadingId == id);
                if (temp == null)
                {
                    throw new TemperatureException("Temperature record not found");
                }
                context.Temperature.Remove(temp);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new TemperatureException(ex.Message);
            }
        }

        public async Task<List<Temperature>> GetAllTemperaturesAsync()
        {
            List<Temperature> temperatures = await context.Temperature.ToListAsync();
            return temperatures;

        }

    }
}
