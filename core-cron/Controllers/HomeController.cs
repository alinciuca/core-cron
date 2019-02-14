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
using System.Collections.Generic;

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

        [Authorize]
        public async Task<IActionResult> Read_WorkingNotWorkingServices()
        {
            var services = await _context.ServiceView.ToListAsync().ConfigureAwait(false);
            if (services.Count == 0)
            {
                return new ContentResult();
            }

            var groups = services.GroupBy(s => s.IsAlive);
            var viewModel = new List<ChartViewModel>();
            foreach (var group in groups)
            {
                var chartViewModel = new ChartViewModel
                {
                    Category = group.Key ? "Working" : "Not working",
                    Value = group.Count()
                };
                viewModel.Add(chartViewModel);
            }

            var json = JsonConvert.SerializeObject(viewModel);
            return new ContentResult { Content = json, ContentType = Constants.JSON_MIME };
        }

        [Authorize]
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
