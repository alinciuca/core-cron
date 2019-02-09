using Core.Cron.Data;
using Core.Cron.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Cron.Controllers
{
	[Route("api/[Controller]")]
	[ApiController]
	public class ServiceApiController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public ServiceApiController(ApplicationDbContext context)
		{
			_context = context;
		}


		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegistrationDto dto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var match = _context.Service.FirstOrDefault(s => s.ServiceName == dto.ServiceName);
			if (match != null)
			{
				return BadRequest("Duplicate service description found! Please specify another name!");
			}

			var service = dto.ToService();

			await _context.Service.AddAsync(service).ConfigureAwait(false);
			await _context.SaveChangesAsync().ConfigureAwait(false);

			return CreatedAtAction("Register", service.ServiceIdentifier);
		}

		[HttpGet("notify")]
		public async Task<IActionResult> Notify(string identifier)
		{
			if (string.IsNullOrWhiteSpace(identifier))
			{
				return BadRequest("Identifier missing!");
			}

			var match = _context.Service.FirstOrDefault(s => s.ServiceIdentifier == identifier);
			if (match == null)
			{
				return NotFound();
			}

			await _context.Heartbeat.AddAsync(new Heartbeat { LastUpdate = DateTime.Now , ServiceId = match.ServiceId}).ConfigureAwait(false);
			await _context.SaveChangesAsync().ConfigureAwait(false);

			return Ok();
		}
	}
}