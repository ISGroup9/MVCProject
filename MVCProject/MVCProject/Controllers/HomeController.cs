using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class HomeController : Controller
    {
        //private FacultyDbContext dbFaculty = new FacultyDbContext();
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to the Information Systems Home Page!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Advisory()
        {
            var model = this.getAdvisoryList();

            return View(model);
        }

        public ActionResult Faculty()
        {
            //var model = dbFaculty.Faculty.ToList();
            var model = this.getFacultyList();

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Courses(string id = "U")
        {
            List<Courses> model;
            switch (id.ToUpper())
            {
                case "G":
                    model = this.getCourseList(CourseLevel.Graduate);
                    break;
                default:
                    model = this.getCourseList(CourseLevel.Undergraduate);
                    break;
            }
            return View(model);
        }

        public List<Faculty> getFacultyList()
        {
            var myList = new List<Faculty>();
            myList.Add(new Faculty { Name = "Conan Albrecht", Email = "ca@byu.edu", Office = "780 TNRB", Picture = "../Images/Professors/calbrecht.jpg" });
            myList.Add(new Faculty { Name = "Gove Allen", Email = "gove@byu.edu", Office = "778 TNRB", Picture = "../Images/Professors/gallen.jpg" });
            myList.Add(new Faculty { Name = "Greg Anderson", Email = "profganderson@byu.edu", Office = "782 TNRB", Picture = "../Images/Professors/ganderson.jpg" });
            myList.Add(new Faculty { Name = "Bonnie Anderson", Email = "anderson@byu.edu", Office = "776 TNRB", Picture = "../Images/Professors/banderson.jpg" });
            myList.Add(new Faculty { Name = "Steve Liddle", Email = "liddle@byu.edu", Office = "784 TNRB", Picture = "../Images/Professors/sliddle.jpg" });
            myList.Add(new Faculty { Name = "Tom Meservy", Email = "tmeservy@byu.edu", Office = "781 TNRB", Picture = "../Images/Professors/tmeservy.jpg" });

            return myList;
        }
        public List<Courses> getCourseList(CourseLevel cLevel)
        {
            var myList = new List<Courses>();
            myList.Add(new Courses { Number = "IS 401", Name = "Systems Analysis and Design", CreditHours = "3", Level = CourseLevel.Undergraduate });
            myList.Add(new Courses { Number = "IS 402", Name = "Database Systems", CreditHours = "3", Level = CourseLevel.Undergraduate });
            myList.Add(new Courses { Number = "IS 403",  Name = "Principles of Business ", CreditHours = "3", Level = CourseLevel.Undergraduate });
            myList.Add(new Courses { Number = "IS 404", Name = "Data Communications", CreditHours = "3", Level = CourseLevel.Undergraduate });
            myList.Add(new Courses { Number = "IS 411", Name = "Systems Design and Implementation", CreditHours = "3", Level = CourseLevel.Undergraduate });
            myList.Add(new Courses { Number = "IS 413", Name = "Enterprise Application Development", CreditHours = "3", Level = CourseLevel.Undergraduate });

            myList.Add(new Courses { Number = "IS 531", Name = "Enterprise Infrastructure", CreditHours = "3", Level = CourseLevel.Graduate });
            myList.Add(new Courses { Number = "IS 550", Name = "MISM Capstone Introduction", CreditHours = ".5", Level = CourseLevel.Graduate });
            myList.Add(new Courses { Number = "IS 551", Name = "Leading Change in a Technical Environment", CreditHours = "3", Level = CourseLevel.Graduate });
            myList.Add(new Courses { Number = "IS 552", Name = "MISM Capstone", CreditHours = "3", Level = CourseLevel.Graduate });
            myList.Add(new Courses { Number = "IS 555", Name = "Data Mining for Business Intelligence", CreditHours = "3", Level = CourseLevel.Graduate });
            myList.Add(new Courses { Number = "IS 560", Name = "Information Security Management", CreditHours = "3", Level = CourseLevel.Graduate });
            myList.Add(new Courses { Number = "IS 562", Name = "Project Management", CreditHours = "3", Level = CourseLevel.Graduate });

            return myList.Where(c => c.Level == cLevel).ToList();
        }
        public List<Advisory> getAdvisoryList()
        {
            var myList = new List<Advisory>();
            myList.Add(new Advisory { Name = "Adam Wariner", Email = "adamwariner@exxonmobil.com", Picture = "../Images/ISAB/awariner.jpg" });
            myList.Add(new Advisory { Name = "Adam Wright", Email = "adamwright@ey.com", Picture = "../Images/ISAB/awright.jpg" });

            return myList;  
        }

    }
}