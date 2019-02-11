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

		public async Task<IActionResult> Read([DataSourceRequest] DataSourceRequest request)
		{
			var results = await _context.Service.ToDataSourceResultAsync(request).ConfigureAwait(false);
			var json = JsonConvert.SerializeObject(results, Formatting.None);
			return new ContentResult { Content = json, ContentType = "application/json" };
		}

		public async Task<IActionResult> Create([DataSourceRequest] DataSourceRequest request, Service service)
		{
			service.ServiceIdentifier = Guid.NewGuid().ToString();
			service.DateAdded = DateTime.Now;

			await _context.Service.AddAsync(service).ConfigureAwait(false);
			await _context.SaveChangesAsync().ConfigureAwait(false);
			var result = await new [] { service }.ToDataSourceResultAsync(request).ConfigureAwait(false);
			var json = JsonConvert.SerializeObject(result);

			return new ContentResult{ Content = json, ContentType = "application/json" };
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
