using Hire_work.DataContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hire_work.Models
{
    public class Test : ViewComponent
    {
        private readonly WorkHireContext _db;

        public Test(WorkHireContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            Worker worker = new Worker();
            worker.Username = "asda";
            if(HttpContext.Session.GetInt32("id") != null)
            {
                var id = (int)HttpContext.Session.GetInt32("id");

                worker = ContextHelper.GetWorkerById(_db, id);
            }

            
            return View(worker);
        }
    }
}
