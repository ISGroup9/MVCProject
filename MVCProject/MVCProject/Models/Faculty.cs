using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    //create the model
    public class Faculty
    {
        //Getters and setters for Faculty: Includes ID, Name, Email, Office, and Picture
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
        //Getter and setter for a list of faculty
        public DbSet<Faculty> Faculty { get; set; }
    }
}