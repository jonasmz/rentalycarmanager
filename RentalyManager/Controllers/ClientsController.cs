using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalyManager.DTOs.Clients;
using RentalyManager.Entities;

namespace RentalyManager.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientsController : ControllerBase
    {
        private readonly AppDbContext __context;
        private readonly IConfiguration __config;

        public ClientsController(AppDbContext context, IConfiguration config)
        {
            this.__context = context;
            this.__config = config;
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add([FromBody] ClientDTO client)
        {
            if (client == null) { return BadRequest("Data client is needed"); }

            var NewClient = new Client
            {
                TradingName = client.TradingName,
                Identifier = client.Identifier,
                Phone = client.Phone,
                Email = client.Email,
                Address = client.Address,
                City = client.City,
                State = client.State,
                Country = client.Country,
                IsPerson = client.IsPerson,
                FiscalCondition = client.FiscalCondition
            };

            try
            {
                await __context.Clients.AddAsync(NewClient);
                await __context.SaveChangesAsync();
                return Ok(NewClient);

            }catch (Exception ex)
            {
                return StatusCode(500, $"An error has ocurred: {ex}");
            }

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ClientDTO clientUpdate)
        {
            if (id < 1) return BadRequest("The id param can't be less than 1");

            try
            {
                var clientToUpdate = await __context.Clients.FirstOrDefaultAsync(c => c.Id == id);
                
                if (clientToUpdate == null) return NotFound("The client can't be found");

                clientToUpdate.TradingName = clientUpdate.TradingName;
                clientToUpdate.Identifier = clientUpdate.Identifier;
                clientToUpdate.Phone = clientUpdate.Phone;
                clientToUpdate.Email = clientUpdate.Email;
                clientToUpdate.Address = clientUpdate.Address;
                clientToUpdate.City = clientUpdate.City;
                clientToUpdate.State = clientUpdate.State;
                clientToUpdate.Country = clientUpdate.Country;
                clientToUpdate.IsPerson = clientUpdate.IsPerson;
                clientToUpdate.FiscalCondition = clientUpdate.FiscalCondition;

                await __context.SaveChangesAsync();
                return Ok(clientToUpdate);

            }catch (Exception ex)
            {
                return StatusCode(500, $"An error has ocurred {ex}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Client>>> Get()
        {
            var max_limit = 100; 
            Int32.TryParse(__config["max_items_per_consult"], out max_limit);

            try
            {
                var result = await __context.Clients.Take(max_limit).ToListAsync();

                if (result == null) return NotFound();

                return Ok(result);
            }catch (Exception ex)
            {
                return StatusCode(500, $"An error has ocurred {ex}");
            }
        }

        [HttpGet("paginate")]
        public async Task<ActionResult<List<Client>>> Paginate([FromQuery] int page, [FromQuery] int limit)
        {
            var max_limit = 25;
            Int32.TryParse(__config.GetSection("Pagination")["Limit"], out max_limit);
            var ipp = (limit > max_limit || limit < 1) ? max_limit : limit;
            var skip = (page - 1 ) * ipp;
            try
            {
                var result = await __context.Clients.Skip(skip).Take(ipp).ToListAsync();

                if (result == null) return StatusCode(404, "Not found Clients");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error has ocurred {ex}");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Client>> GetById(int id)
        {
            if (id < 1) return BadRequest("The id param can't be less than 1");

            try
            {
                var result = await __context.Clients.FirstOrDefaultAsync(c => c.Id == id);
                if (result == null) return NotFound("Client not found");
                return Ok(result);
            }catch (Exception ex)
            {
                return StatusCode(500, $"An error has ocurred {ex}");
            }
        }

        [HttpGet("{identifier}")]
        public async Task<ActionResult<Client>> SearchByIdentifier(string identifier)
        {
            if (identifier == null) return BadRequest("Identifier param is required");

            try
            {
                var resut = await __context.Clients.Where(c => c.Identifier == identifier).FirstOrDefaultAsync();
                return Ok(resut);
            }catch (Exception ex)
            {
                return StatusCode(500, $"An error has been ocurred: {ex}");
            }
        }
    }
}
