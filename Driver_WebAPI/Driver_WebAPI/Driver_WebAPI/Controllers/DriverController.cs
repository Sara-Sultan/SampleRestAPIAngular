using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Driver.Application.IServices;
using Driver.Application.DTO;

namespace Driver_WebAPI.Controllers
{
    [ApiController]
    [Route("api/Driver")]
    [EnableCors("AllowOrigin")]
    public class DriverController : ControllerBase
    {
        private readonly ILogger<DriverController> _logger;
        private readonly IServiceManager _serviceManager;

        public DriverController(IServiceManager serviceManager, ILogger<DriverController> logger)
        {
            _logger = logger;
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetDriver(CancellationToken cancellationToken)
        {
            var Driver = await _serviceManager.DriverService.GetAllAsync( cancellationToken);

            return Ok(Driver);
        }

        [HttpGet("{DriverId:guid}")]
        public async Task<IActionResult> GetDriverById(Guid driverId, CancellationToken cancellationToken)
        {
            var DriverDto = await _serviceManager.DriverService.GetByIdAsync(driverId, cancellationToken);

            return Ok(DriverDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDriver([FromBody] DriverForCreationDto DriverForCreationDto)
        {
            var DriverDto = await _serviceManager.DriverService.CreateAsync(DriverForCreationDto);

            // return CreatedAtAction(nameof(GetDriverById), new { DriverId = DriverDto.Id }, DriverDto);
            return Ok(new ResponseDTO()
            {
                success = true,
                results = DriverDto,
                messages = ""
            });
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateDriver([FromBody] DriverForUpdateDto DriverForUpdateDto, CancellationToken cancellationToken)
        {
            await _serviceManager.DriverService.UpdateAsync( DriverForUpdateDto, cancellationToken);

            return Ok(new ResponseDTO()
            {
                success = true,
                results = DriverForUpdateDto,
                messages = ""
            });
        }

        [HttpDelete("{DriverId:guid}")]
        public async Task<IActionResult> DeleteDriver(Guid DriverId, CancellationToken cancellationToken)
        {
            await _serviceManager.DriverService.DeleteAsync(DriverId, cancellationToken);

            return NoContent();
        }
    }


}
