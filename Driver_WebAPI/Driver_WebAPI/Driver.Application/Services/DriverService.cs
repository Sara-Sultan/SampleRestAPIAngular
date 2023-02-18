using Driver.Application.DTO;
using Driver.Application.IServices;
using Driver.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Driver.Application.Services
{
    internal sealed class DriverService : IDriverService
    {
        string filePath = @"./drivers.json";
        public DriverService() { }

        public async Task<IEnumerable<DriverDTO>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            string text = File.ReadAllText(filePath);
            var Drivers = JsonSerializer.Deserialize<List<DriverEntity>>(text);

            var DriversDto = Mapping.MapperObject.Mapper.Map<IEnumerable< DriverDTO >> ( Drivers);

            return DriversDto;
        }

        public async Task<DriverDTO> GetByIdAsync(Guid DriverId, CancellationToken cancellationToken = default)
        {
            string text = File.ReadAllText(filePath);
            var Drivers = JsonSerializer.Deserialize<List<DriverEntity>>(text);
            var Driver = Drivers.Where(d=>d.Id == DriverId).FirstOrDefault();

            if (Driver is null)
            {
                throw new Exception("Not Found");
            }

            var DriverDTO = Mapping.MapperObject.Mapper.Map<DriverDTO>( Driver);

            return DriverDTO;
        }

        public async Task<DriverDTO> CreateAsync(DriverForCreationDto DriverForCreationDto, CancellationToken cancellationToken = default)
        {
            string text = File.ReadAllText(filePath);
            var Drivers = JsonSerializer.Deserialize<List<DriverEntity>>(text);
            if(Drivers==null)
                Drivers = new List<DriverEntity>();
            var driver = Mapping.MapperObject.Mapper.Map<DriverEntity>(DriverForCreationDto);
            driver.Id = Guid.NewGuid();

            Drivers.Add(driver);
            string jsonString = JsonSerializer.Serialize(Drivers, new JsonSerializerOptions() { WriteIndented = true });
            using (StreamWriter outputFile = new StreamWriter(filePath))
            {
                outputFile.WriteLine(jsonString);
            }

            return Mapping.MapperObject.Mapper.Map<DriverDTO>(driver);
        }

        public async Task UpdateAsync(DriverForUpdateDto DriverForUpdateDto, CancellationToken cancellationToken = default)
        {
            string text = File.ReadAllText(filePath);
            var Drivers = JsonSerializer.Deserialize<List<DriverEntity>>(text);

            var driver = await GetByIdAsync(DriverForUpdateDto.Id, cancellationToken);

            if (driver is null)
            {
                throw new Exception("Not Found");
            }
            foreach (var dr in Drivers.Where(d => d.Id == DriverForUpdateDto.Id))
            {
                dr.FirstName = DriverForUpdateDto.FirstName;
                dr.LastName = DriverForUpdateDto.LastName;
                dr.Email = DriverForUpdateDto.Email;
                dr.PhoneNumber = DriverForUpdateDto.PhoneNumber;
            }
            string jsonString = JsonSerializer.Serialize(Drivers, new JsonSerializerOptions() { WriteIndented = true });
            using (StreamWriter outputFile = new StreamWriter(filePath))
            {
                outputFile.WriteLine(jsonString);
            }
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid DriverId, CancellationToken cancellationToken = default)
        {
            string text = File.ReadAllText(filePath);
            var Drivers = JsonSerializer.Deserialize<List<DriverEntity>>(text);

            var driver = await GetByIdAsync(DriverId, cancellationToken);

            if (driver is null)
            {
                throw new Exception("Not Found");
            }
            Drivers.RemoveAll((x) => x.Id == DriverId);
            string jsonString = JsonSerializer.Serialize(Drivers, new JsonSerializerOptions() { WriteIndented = true });
            using (StreamWriter outputFile = new StreamWriter(filePath))
            {
                outputFile.WriteLine(jsonString);
            }
            await Task.CompletedTask;
        }
    }
}
