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
			DataSourceResult results = await _context.ServiceView.ToDataSourceResultAsync(request).ConfigureAwait(false);
			var json = JsonConvert.SerializeObject(results, Formatting.None);
			return new ContentResult { Content = json, ContentType = Constants.JSON_MIME };
		}

		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([DataSourceRequest] DataSourceRequest request, ServiceView service)
		{
			var newService = service.ToDbModel();
			await _context.Service.AddAsync(newService).ConfigureAwait(false);
			await _context.SaveChangesAsync().ConfigureAwait(false);
			
			service.ServiceId = newService.ServiceId;
			service.ServiceIdentifier = newService.ServiceIdentifier;
			service.DateAdded = newService.DateAdded;
			service.RowVersion = newService.RowVersion;

			var result = await new[] { service }.ToDataSourceResultAsync(request).ConfigureAwait(false);
			var json = JsonConvert.SerializeObject(result);

			return new ContentResult { Content = json, ContentType = Constants.JSON_MIME };
		}

		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Update([DataSourceRequest] DataSourceRequest request, ServiceView service)
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
			service.RowVersion = existingService.RowVersion;
			var result = await new[] { service }.ToDataSourceResultAsync(request).ConfigureAwait(false);
			var json = JsonConvert.SerializeObject(result);
			return new ContentResult { Content = json, ContentType = Constants.JSON_MIME };
		}

		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete([DataSourceRequest] DataSourceRequest request, ServiceView service)
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
