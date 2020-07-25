using Hire_work.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hire_work.Models.Interfaces
{
    public interface IAdvert
    {
        int Id { get; set; }

        string AdvertName { get; set; }

        string Description { get; set; }

        int WorkHours { get; set; }

        string Address { get; set; }

        string PhoneNumber { get; set; }

        string EmailAddress { get; set; }

        decimal HourPayment { get; set; }

        decimal MonthlyPayment { get; set; }

        DateTime Date { get; set; }

        City City { get; set; }

        MainCategory MainCategory { get; set; }

       
    }
}
