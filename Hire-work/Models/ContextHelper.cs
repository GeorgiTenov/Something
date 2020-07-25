using Hire_work.DataContext;
using Hire_work.Models.Enums;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hire_work.Models
{
    public static class ContextHelper
    {
        private static WorkHireContext _db;
        public static void AddAdvert(WorkHireContext dbContext,Advert advert)
        {
            _db = dbContext;

            _db.Adverts.Add(advert);

            _db.SaveChanges();
        }

        public static void RemoveAdvert(WorkHireContext dbContext,Advert advert)
        {
            _db = dbContext;

            _db.Adverts.Remove(advert);

            _db.SaveChanges();
        }

        public static  void RemoveAllAdverts(WorkHireContext dbContext)
        {
            _db = dbContext;

            _db.Adverts.RemoveRange(_db.Adverts);

            _db.SaveChanges();
        }

        public static Advert GetAdvertByName(WorkHireContext dbContext,string advertName)
        {
            _db = dbContext;

            return _db.Adverts.FirstOrDefault(a => a.AdvertName.Equals(advertName));
        }

        public static List<Advert> GetAdvertsByDate(WorkHireContext dbContext,DateTime date)
        {
            _db = dbContext;

            return _db.Adverts.Where(a => a.Date == date).ToList();
        }

        public static List<Advert>GetAdvertsByCategory(WorkHireContext dbContext,
                                                       MainCategory category)
        {
            _db = dbContext;

            return _db.Adverts.Where(a => a.MainCategory == category).ToList();
        }

        public static List<Advert>GetAdvertsByCity(WorkHireContext dbContext,City city)
        {
            _db = dbContext;

            return _db.Adverts.Where(a => a.City == city).ToList();
        }

        public static List<Advert> GetAdverts(WorkHireContext dbContext)
        {
            _db = dbContext;

            return _db.Adverts.ToList();
        }

        public static int GetTotalAdvertsCount(WorkHireContext dbContext)
        {
            _db = dbContext;

            return _db.Adverts.Count();
        }

        public static void AddWorker(WorkHireContext dbContext,Worker worker)
        {
            _db = dbContext;

            _db.Workers.Add(worker);

            _db.SaveChanges();
        }

        public static void RemoveWorker(WorkHireContext dbContext,Worker worker)
        {
            _db = dbContext;

            _db.Workers.Remove(worker);

            _db.SaveChanges();
        }

        public static void RemoveAllWorkers(WorkHireContext dbContext)
        {
            _db = dbContext;

            _db.Workers.RemoveRange(_db.Workers);

            _db.SaveChanges();
        }

        public static Worker GetWorkerById(WorkHireContext dbContext, int id)
        {
            _db = dbContext;

            return _db.Workers.FirstOrDefault(w => w.Id == id);
        }

        public static Worker GetWorkerByUsername(WorkHireContext dbContext,string username)
        {
            _db = dbContext;

            return _db.Workers.FirstOrDefault(w => w.Username.Equals(username));
        }

        public static Worker GetWorkerByFirstName(WorkHireContext dbContext,string firstName)
        {
            _db = dbContext;

            return _db.Workers.FirstOrDefault(w => w.FirstName.Equals(firstName));
        }

        public static Worker GetWorkerByLastName(WorkHireContext dbContext, string lastName)
        {
            _db = dbContext;

            return _db.Workers.FirstOrDefault(w => w.LastName.Equals(lastName));
        }

        public static List<Worker> GetWorkers(WorkHireContext dbContext)
        {
            _db = dbContext;

            return _db.Workers.ToList();
        }

        public static List<Worker> GetWorkersByCity(WorkHireContext dbContext,City city)
        {
            _db = dbContext;

            return _db.Workers.Where(w => w.City == city).ToList();
        }

        public static Worker GetWorkerByEmail(WorkHireContext dbContext,string email)
        {
            _db = dbContext;

            return _db.Workers.FirstOrDefault(w => w.EmailAddress.Equals(email));
        }
        public static int GetTotalWorkersCount(WorkHireContext dbContext)
        {
            _db = dbContext;

            return _db.Workers.Count();
        }

        public static Advert GetAdvertById(WorkHireContext dbContext,int id)
        {
            _db = dbContext;

            var advert = GetAdverts(_db).FirstOrDefault(a => a.Id == id);

            return advert;
        }

       
    }
}
