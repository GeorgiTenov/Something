using Hire_work.Models.Enums;
using Hire_work.Models.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hire_work.Models
{
    public class Advert : IAdvert
    {
        public int Id { get; set; }

        public string AdvertName { get; set; }

        public string Description { get; set; }

        public int WorkHours { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public decimal HourPayment { get; set; }

        public decimal MonthlyPayment { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public City City { get; set; }

        public MainCategory MainCategory { get; set; }

        public Advert() { }

        public Advert(string advertName,
                      string description,
                      int workHours,
                      string address,
                      string phoneNumber,
                      string emailAddress,
                      decimal hourPayment,
                      decimal monthlyPayment,
                      City city,
                      MainCategory mainCategory)
        {
            this.AdvertName = advertName;

            this.Description = description;

            this.WorkHours = workHours;

            this.Address = address;

            this.PhoneNumber = phoneNumber;

            this.EmailAddress = emailAddress;

            this.HourPayment = hourPayment;

            this.MonthlyPayment = monthlyPayment;

            this.City = city;

            this.MainCategory = mainCategory;
        }

        public void SerializeAdverts(List<Advert> adverts)
        {
            var jsonAdverts = JsonConvert.SerializeObject(adverts);
        }

        public static void SaveJsonAdverts(IWebHostEnvironment host, List<Advert> adverts)
        {
            string roothPath = host.WebRootPath;

            string fullPath = Path.Combine(roothPath + "/JsonData/", "Adverts.json");

            var convertedJson = JsonConvert.SerializeObject(adverts);

            FileStream filestream = new FileStream(fullPath, FileMode.Open);
            filestream.Close();

            StreamWriter sw = new StreamWriter(fullPath, false);
            sw.Write(convertedJson);
            sw.Close();

        }
    }
}
