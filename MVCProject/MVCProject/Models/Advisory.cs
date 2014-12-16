using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class Advisory
    {
       //Getters and setters for Advisory page - Includes: ID, Name, Email, Picture
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }


        public string Picture { get; set; }
    }

    public class AdvisoryDbContext : DbContext
    {
        //Getter and setter for advisory list.
        public DbSet<Advisory> Advisory { get; set; }
    }
}