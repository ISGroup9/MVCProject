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
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Required]
        public DegreeType Degree_Type { get; set; }

        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
    }

    public class ContactDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
    }
}