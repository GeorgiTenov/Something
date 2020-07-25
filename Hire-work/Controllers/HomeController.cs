using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Hire_work.Models;
using Hire_work.DataContext;
using Microsoft.AspNetCore.Hosting;

namespace Hire_work.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly WorkHireContext _db;

        private readonly IWebHostEnvironment _host;
        public HomeController(ILogger<HomeController> logger,WorkHireContext db,IWebHostEnvironment host)
        {
            _logger = logger;

            _db = db;

            _host = host;

        }

        public IActionResult Index()
        {
            //ContextHelper.RemoveAllWorkers(_db);
            //ContextHelper.RemoveAllAdverts(_db);
            Advert.SaveJsonAdverts(_host, ContextHelper.GetAdverts(_db));
            if (_db.Workers.Count() > 0)
            {
                return View(ContextHelper.GetWorkers(_db));
            }

            
            return View();
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
