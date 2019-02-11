using Core.Cron.Data;
using Core.Cron.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Core.Cron.Logic;
using System.Linq;

namespace Core.Cron.Controllers
{
	public class HomeController : Controller
	{
		private readonly ApplicationDbContext _context;

		public HomeController(ApplicationDbContext context)
		{
			_context = context;
		}

		[Authorize()]
		public IActionResult Index()
		{
			return View();
		}

		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Read([DataSourceRequest] DataSourceRequest request)
		{
			var results = await _context.Service.ToDataSourceResultAsync(request).ConfigureAwait(false);
			var json = JsonConvert.SerializeObject(results, Formatting.None);
			return new ContentResult { Content = json, ContentType = Constants.JSON_MIME };
		}

		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([DataSourceRequest] DataSourceRequest request, Service service)
		{
			service.ServiceIdentifier = Guid.NewGuid().ToString();
			service.DateAdded = DateTime.Now;

			await _context.Service.AddAsync(service).ConfigureAwait(false);
			await _context.SaveChangesAsync().ConfigureAwait(false);
			var result = await new[] { service }.ToDataSourceResultAsync(request).ConfigureAwait(false);
			var json = JsonConvert.SerializeObject(result);

			return new ContentResult { Content = json, ContentType = Constants.JSON_MIME };
		}

		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Update([DataSourceRequest] DataSourceRequest request, Service service)
		{
			var existingService = await _context.Service.FindAsync(service.ServiceId).ConfigureAwait(false);
			if (existingService == null)
			{
				ModelState.AddModelError("Not found!", "Service cannot be found!");
				return BadRequest(ModelState);
			}

			if (!existingService.RowVersion.SequenceEqual(service.RowVersion))
			{
				ModelState.AddModelError("Concurrency Error", "Someone already made changes to this service. Please refresh!");
				return BadRequest(ModelState);
			}

			existingService.ServiceName = service.ServiceName;
			await _context.SaveChangesAsync().ConfigureAwait(false);
			var result = await new[] { existingService }.ToDataSourceResultAsync(request).ConfigureAwait(false);
			var json = JsonConvert.SerializeObject(result);
			return new ContentResult { Content = json, ContentType = Constants.JSON_MIME };
		}

		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete([DataSourceRequest] DataSourceRequest request, Service service)
		{
			var existingService = await _context.Service.FindAsync(service.ServiceId).ConfigureAwait(false);
			if (existingService == null)
			{
				ModelState.AddModelError("Delete Error", "The service was already deleted!");
				return BadRequest(ModelState);
			}

			_context.Service.Remove(existingService);
			await _context.SaveChangesAsync().ConfigureAwait(false);

			return new ContentResult();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
