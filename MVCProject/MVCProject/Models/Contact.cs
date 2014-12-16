using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{

    //This is the contact model. It has an ID, the Name of the Person, and Email address (validated),
    //A Degree Type object, and optional notes
    public class Contact
    {
        //Getters and setters for the contact informatino from the contact page. Includes:Name, Email, DegreeType, and Notes
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
        //Getter and setter for Contacts list.
        public DbSet<Contact> Contacts { get; set; }
    }
}