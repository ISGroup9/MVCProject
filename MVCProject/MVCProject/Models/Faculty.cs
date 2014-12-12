using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class Faculty
    {
        public int ID { get; set; }

        //[Required]
        public string Name { get; set; }

        //[Required]
        public string Email { get; set; }

        //[Required]
        public string Office { get; set; }

        public string Picture { get; set; }
    }

    public class FacultyDbContext : DbContext
    {
        public DbSet<Faculty> Faculty { get; set; }
    }
}