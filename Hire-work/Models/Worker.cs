using Hire_work.DataContext;
using Hire_work.Models.Enums;
using Hire_work.Models.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Hire_work.Models
{
    public class Worker : IWorker
    {
        private  WorkHireContext _db;
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string EmailAddress { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Description { get; set; }

        public string Portfolio { get; set; }

        [NotMapped]
        public IFormFile Picture { get; set; }

        public string PicturePath { get; set; }

        public MainCategory MainCategory { get; set; }

        public City City { get; set; }

        public decimal StartingHourFee { get; set; }

        public bool IsLogged { get; set; }

        public bool IsRegistered { get; set; }

        public Worker() 
        {
            
        }

        public Worker(string username,
                      string password,
                      string emailAddress,
                      string firstName,
                      string lastName,
                      string phone,
                      string description,
                      string portfolio,
                      MainCategory category,
                      City city,
                      WorkHireContext db,
                      IFormFile picture = null,
                      decimal startingHourFee = 10)
        {
            this.Username = username;

            this.Password = password;

            this.EmailAddress = emailAddress;

            this.FirstName = firstName;

            this.LastName = lastName;

            this.Phone = phone;

            this.Description = description;

            this.Portfolio = portfolio;

            this.MainCategory = category;

            this.City = city;

            this.Picture = picture;

            this.StartingHourFee = startingHourFee;

            _db = db;
        }
        public void SetDbContext(WorkHireContext dbContext)
        {
            _db = dbContext;
        }

        public void ChangeUserName(string username)
        {
            this.Username = username;

            _db.SaveChanges();
        }

        public void SetLogIn(WorkHireContext dbContext)
        {
            _db = dbContext;

            this.IsLogged = true;

            _db.SaveChanges();
        }

        public void SetLogOut(WorkHireContext dbContext)
        {
            _db = dbContext;

            this.IsLogged = false;

            _db.SaveChanges();
        }

        public void SetRegistered(WorkHireContext dbContext)
        {
            _db = dbContext;

            this.IsRegistered = true;

            _db.SaveChanges();
        }

        public void SavePicture(IWebHostEnvironment host,IFormFile picture)
        {
            string root = host.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(picture.FileName);
            string extension = Path.GetExtension(picture.FileName);
            string fullPath = Path.Combine(root + "/Images/", fileName + extension);
            this.PicturePath = fileName + extension;
            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                Picture.CopyTo(fileStream);
            }
        }
    }
}
