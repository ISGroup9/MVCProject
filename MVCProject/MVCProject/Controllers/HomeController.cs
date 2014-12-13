//group 1:9 
//taylor curtis, landon curtis, john meservy, ben willard
//date: 12/12/14
//description: this program is a simple mvc program for the byu information systems department. it has a home page with a menu across the top that allows
//the user to navigate (link) to the other pages. There is a page for viewing the undergraduate courses, graduate courses, a page to view faculty members, and a page 
//to view the advisory board members. There is also a page to contact us with questions. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.Models;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace MVCProject.Controllers
{
    public class HomeController : Controller
    {
        //private FacultyDbContext dbFaculty = new FacultyDbContext();
        public ActionResult Index()
        {
            var model = getDegreeTypeList();

            ViewBag.Type = new SelectList(model,"Type","Type");
            //message that is displayed on the home page screen
            ViewBag.Message = "Welcome to the Information Systems Home Page!";

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            var opt = form["Type"];
            if(opt == "Undergraduate Degree" )
                return RedirectToAction("Courses");
            else return RedirectToAction("Courses/G");

        }

        //public ActionResult About()
        //{
        //    return View();
        //}

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

      

        public ActionResult Courses(string id = "U")
        {
            List<Courses> model;
            switch (id.ToUpper())
            {
                case "G":
                    model = this.getCourseList(CourseLevel.Graduate);
                    ViewBag.Message = "Graduate Courses";
                    break;
                default:
                    model = this.getCourseList(CourseLevel.Undergraduate);
                    ViewBag.Message = "Undergraduate Courses";
                    break;
            }
            return View(model);
        }

        //the faculty list: the name, email, office, and picture of each professor are added to a list and then retrieved to be used in displaying
        //the information for each professor on the faculty page
        public List<Faculty> getFacultyList()
        {
            var myList = new List<Faculty>();
            myList.Add(new Faculty { Name = "Conan Albrecht", Email = "ca@byu.edu", Office = "780 TNRB", Picture = "../Images/Professors/calbrecht.jpg" });
            myList.Add(new Faculty { Name = "Gove Allen", Email = "gove@byu.edu", Office = "778 TNRB", Picture = "../Images/Professors/gallen.jpg" });
            myList.Add(new Faculty { Name = "Greg Anderson", Email = "profganderson@byu.edu", Office = "782 TNRB", Picture = "../Images/Professors/ganderson.jpg" });
            myList.Add(new Faculty { Name = "Bonnie Anderson", Email = "anderson@byu.edu", Office = "776 TNRB", Picture = "../Images/Professors/banderson.jpg" });
            myList.Add(new Faculty { Name = "Steve Liddle", Email = "liddle@byu.edu", Office = "784 TNRB", Picture = "../Images/Professors/sliddle.jpg" });
            myList.Add(new Faculty { Name = "Tom Meservy", Email = "tmeservy@byu.edu", Office = "781 TNRB", Picture = "../Images/Professors/tmeservy.jpg" });
            myList.Add(new Faculty { Name = "Marshall Romney", Email = "mromney@byu.edu", Office = "790A TNRB", Picture = "../Images/Professors/mromney.jpg" });

            return myList;
        }

        public static List<DegreeType> getDegreeTypeList()
        {
            var myList = new List<DegreeType>();
            myList.Add(new DegreeType { Type = "Undergraduate Degree" });
            myList.Add(new DegreeType { Type = "Graduate Degree" });
            return myList;
        }

        //the course list: the number, name, credit hour, and type (grad/undergrad) of each course are added to a list of courses and then are
        //retrieved and displayed on their respective page, either grad or undergrad, depending on the course level. 
        public List<Courses> getCourseList(CourseLevel cLevel)
        {
            var myList = new List<Courses>();
            myList.Add(new Courses { Number = "IS 401", Name = "Systems Analysis and Design", CreditHours = "3", Level = CourseLevel.Undergraduate });
            myList.Add(new Courses { Number = "IS 402", Name = "Database Systems", CreditHours = "3", Level = CourseLevel.Undergraduate });
            myList.Add(new Courses { Number = "IS 403", Name = "Principles of Business ", CreditHours = "3", Level = CourseLevel.Undergraduate });
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

        //the advisory board list: the name, email, and picture of each board member are added to a list and then retrieved to be used in displaying
        //the information for each board member on the respective page
        public List<Advisory> getAdvisoryList()
        {
            var myList = new List<Advisory>();
            myList.Add(new Advisory { Name = "Adam Wariner", Email = "adamwariner@exxonmobil.com", Picture = "../Images/ISAB/awariner.jpg" });
            myList.Add(new Advisory { Name = "Adam Wright", Email = "adamwright@ey.com", Picture = "../Images/ISAB/awright.jpg" });

            return myList;
        }

        


    }
}