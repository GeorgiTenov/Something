using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hire_work.DataContext;
using Hire_work.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Hire_work.Controllers
{
    public class AdvertController : Controller
    {
        private readonly WorkHireContext _db;

        private readonly IWebHostEnvironment _host;

        public AdvertController(WorkHireContext db,IWebHostEnvironment host)
        {
            _db = db;

            _host = host;
        }
        public IActionResult Index()
        {
          
            return View();
        }

        public RedirectToActionResult Accepted(Advert advert)
        {
            ContextHelper.AddAdvert(_db, advert);

            return RedirectToAction("Index","Home");
        }

        public IActionResult AdvertDetails(int? id)
        {
            Advert advert = null;
            if(id != null)
            {
                advert = ContextHelper.GetAdvertById(_db,(int)id);
            }

            return View(advert);
        }
    }
}