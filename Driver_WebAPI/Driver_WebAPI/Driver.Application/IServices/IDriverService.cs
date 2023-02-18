using Driver.Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Driver.Application.IServices
{
    public interface IDriverService
    {
        Task<IEnumerable<DriverDTO>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<DriverDTO> GetByIdAsync(Guid DriverId, CancellationToken cancellationToken = default);

        Task<DriverDTO> CreateAsync(DriverForCreationDto DriverForCreationDto, CancellationToken cancellationToken = default);

        Task UpdateAsync(DriverForUpdateDto DriverForUpdateDto, CancellationToken cancellationToken = default);

        Task DeleteAsync(Guid DriverId, CancellationToken cancellationToken = default);
    }
}
