using Hire_work.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hire_work.DataContext
{
    public class WorkHireContext : DbContext
    {
        public WorkHireContext(DbContextOptions options) : base(options) { }

        public DbSet<Advert> Adverts { get; set; }

        public DbSet<Worker> Workers { get; set; }


    }
}
