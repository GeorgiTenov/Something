using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hire_work.DataContext;
using Hire_work.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hire_work.Controllers
{
    public class WorkerController : Controller
    {
        private readonly WorkHireContext _db;


        private readonly IWebHostEnvironment _host;

        public WorkerController(WorkHireContext db,IWebHostEnvironment host)
        {
            _db = db;

            

            _host = host;
        }
        public IActionResult Index()
        {
            return View();
        }

        public RedirectToActionResult Register(Worker worker)
        {
            var employee = ContextHelper.GetWorkers(_db)
                .FirstOrDefault(w => w.Username.Equals(worker.Username) 
                            || w.EmailAddress.Equals(worker.EmailAddress) );

            if (employee == null)
            {
                if(worker.Picture != null)
                {
                    worker.SavePicture(_host, worker.Picture);
                }
                
               
                ContextHelper.AddWorker(_db, worker);
                
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index");
            
        }

        public RedirectToActionResult Logged(string username,string password)
        {
            var worker = ContextHelper.GetWorkers(_db)
                .FirstOrDefault(w => w.Username.Equals(username) 
                && w.Password.Equals(password));

            if(worker == null)
            {
                return RedirectToAction("Index");
            }
            worker.SetLogIn(_db);
            HttpContext.Session.SetInt32("id",worker.Id);
            return RedirectToAction("Index","Home");
        }

        public IActionResult Login()
        {
            if (HttpContext.Session.GetInt32("id") != null)
            {
                var worker = ContextHelper.GetWorkerById(_db, (int)HttpContext.Session.GetInt32("id"));
                if (worker.IsLogged)
                {
                    return RedirectToAction("WorkPage");
                }
            }
           
            return View();
        }

        public RedirectToActionResult LogOut()
        {
            var worker = ContextHelper.GetWorkerById(_db,(int) HttpContext.Session.GetInt32("id"));
            worker.SetLogOut(_db);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult _SignManager()
        {
            var id = (int)HttpContext.Session.GetInt32("id");
            var worker = ContextHelper.GetWorkerById(_db,id);
            return View(worker);
        }

        public IActionResult WorkPage()
        {
            var adverts = ContextHelper.GetAdverts(_db);
            return View(adverts);
        }

       
    }
}