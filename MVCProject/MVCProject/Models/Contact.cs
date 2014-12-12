using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class Contact
    {
        public int ID { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string GradPlan { get; set; }

        public string Notes { get; set; }
    }

    public class ContactDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
    }
}