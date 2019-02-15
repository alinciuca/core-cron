using Core.Cron.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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

		[HttpGet("notify")]
		public async Task<IActionResult> Notify(string identifier)
		{
			if (string.IsNullOrWhiteSpace(identifier))
			{
				return BadRequest("Identifier missing!");
			}

			var match = await _context.Service.FirstOrDefaultAsync(s => s.ServiceIdentifier == identifier).ConfigureAwait(false);
			if (match == null)
			{
				return NotFound();
			}

			await _context.Heartbeat.AddAsync(new Heartbeat { LastUpdate = DateTimeOffset.Now , ServiceId = match.ServiceId}).ConfigureAwait(false);
			await _context.SaveChangesAsync().ConfigureAwait(false);

			return Ok();
		}
	}
}