using Hire_work.Models.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hire_work.Models.Interfaces
{
    public interface IWorker
    {
        int Id { get; set; }

        string Username { get; set; }

        string Password { get; set; }

        string EmailAddress { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        string Phone { get; set; }

        string Description { get; set; }

        string Portfolio { get; set; }

        IFormFile Picture { get; set; }

        string PicturePath { get; set; }

        MainCategory MainCategory { get; set; }

        decimal StartingHourFee { get; set; }

        City City { get; set; }
    }
}
