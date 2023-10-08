using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalyManager.DTOs.Vehicles;
using RentalyManager.Entities;

namespace RentalyManager.Controllers
{
    [ApiController]
    [Route("api/vehicles")]
    public class VehiclesController : ControllerBase
    {
        private readonly AppDbContext __context;
        private readonly IConfiguration __config;

        public VehiclesController(AppDbContext context, IConfiguration config)
        {
            this.__context = context;
            this.__config = config;
        }

        [HttpPost]
        public async Task<ActionResult> Add(VehicleDTO vehicle)
        {
            if (vehicle == null) return BadRequest("The vehicle param is required");

            var newVehicle = new Vehicle
            {
                Name = vehicle.Name,
                Brand = vehicle.Brand,
                Model = vehicle.Model,
                Identifier = vehicle.Identifier,
                Gama = vehicle.Gama,
                Available = vehicle.Available,
                IsActive = vehicle.IsActive
            };

            try
            {
                await __context.Vehicles.AddAsync(newVehicle);
                await __context.SaveChangesAsync();
                return Ok(newVehicle);
            } catch (Exception ex)
            {
                return StatusCode(500, $"An erros has ocurred {ex}");
            }

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, VehicleDTO vehicle)
        {
            if (id < 1) return BadRequest("The id param can't be less than 1");
            if (vehicle == null) return BadRequest("The vehicle param can't be null");

            try
            {
                var result = await __context.Vehicles.FirstOrDefaultAsync(v => v.Id == id);
                if (result == null) return NotFound("Vehicle resource not found");

                result.Name = vehicle.Name;
                result.Brand = vehicle.Brand;
                result.Identifier = vehicle.Identifier;
                result.Model = vehicle.Model;
                result.Gama = vehicle.Gama;
                result.Available = vehicle.Available;
                result.IsActive = vehicle.IsActive;

                await __context.SaveChangesAsync();

                return Ok();
            }catch (Exception ex)
            {
                return StatusCode(500, $"An Error has ocurred {ex}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Vehicle>>> Get()
        {
            var max_items = 100;
            Int32.TryParse(__config["max_items_per_consult"], out max_items);

            try
            {
                var result = await __context.Vehicles.Take(max_items).ToListAsync();
                if (result == null) return NotFound();
                return Ok(result);
            } catch (Exception ex)
            {
                return StatusCode(500, $"An error has ocurred {ex}");
            }
        }

        [HttpGet("paginate")]
        public async Task<ActionResult<List<Vehicle>>> Paginate([FromHeader] int page, [FromHeader] int limit)
        {
            var max_limit = 25;
            Int32.TryParse(__config.GetSection("Pagination")["Limit"], out max_limit);
            var ipp = (limit > max_limit || limit < 1) ? max_limit : limit;
            var skip = (page - 1) * ipp;

            try
            {
                var result = await __context.Vehicles.Skip(skip).Take(ipp).ToListAsync();

                if (result == null || result.Count == 0) return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error has ocurred {ex}");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Vehicle>> GetById(int id)
        {
            if (id < 1) return BadRequest("The id param can't be less than 1");

            try
            {
                var result = await __context.Vehicles.FirstOrDefaultAsync(a => a.Id == id);
                if (result == null) return NotFound();
                return Ok(result);
            }catch (Exception ex)
            {
                return StatusCode(500, $"An error has ocurred {ex}");
            }
        }

        [HttpGet("{identifier}")]
        public async Task<ActionResult<Vehicle>> GetByIdentifier(string identifier)
        {
            if (identifier == null) return BadRequest("The id param can't be less than 1");

            try
            {
                var result = await __context.Vehicles.FirstOrDefaultAsync(a => a.Identifier.Contains(identifier.ToUpper()));
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error has ocurred {ex}");
            }
        }

        [HttpGet("available")]
        public async Task<ActionResult<List<Vehicle>>> getAvailables()
        {
            try
            {
                var result = await __context.Vehicles.Where(v => v.Available == true).ToListAsync();
                if (result == null || result.Count < 1) return NotFound("There are no vehicles available");

                return Ok(result);
            }catch(Exception ex)
            {
                return StatusCode(500, $"An error has ocurred: {ex}");
            }
        }
    }
}
