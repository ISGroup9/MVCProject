using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public enum CourseLevel
    {
        //Sets undergraduate to 0, graduate to 1.
        Undergraduate = 0,
        Graduate = 1
    }

    public class Courses
    {
       //Getters and setters for courses - Includes: ID, Number, Name, CreditHours, and Courselevel(the enum declared above)
        public int ID { get; set; }
        [Required]
        public string Number { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string CreditHours { get; set; }

        [Required]
        public CourseLevel Level { get; set; }
    }

    public class CoursesDbContext : DbContext
    {
        //Getter and setter for course list.
        public DbSet<Courses> Courses { get; set; }
    }
}