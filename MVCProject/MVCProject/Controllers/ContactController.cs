using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.Models;
using System.Net.Mail;
using System.Net;
using MVCProject.Controllers;

namespace MVCProject.Controllers
{
    public class ContactController : Controller
    {
        private ContactDbContext db = new ContactDbContext();

        //
        // GET: /Contact/Create
        //Here is what is called when you navigate to this page
        public ActionResult Create()
        {
            //creates a list that has the dropdownlist items
            var list = new SelectList(HomeController.getDegreeTypeList(), "Type", "Type");
            //sticks it in the viewbag
            ViewBag.Types = list;
            //sends the view
            return View();
        }

        //
        // POST: /Contact/Create
        //Called when submitting the form. The contact model is passed
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contact contact)
        {
            //Checks to see if the model is valid

            if (ModelState.IsValid)
            {
                //sets who the email is from

                    string from = "informationsystemsbyu@gmail.com";
                    
                    //creates a new mail message
                    using (MailMessage mail = new MailMessage(from, contact.Email))
                    {
                        //sets the name of the sender
                        mail.From = new MailAddress(from, "BYU Information Systems");
                        //sets the subject
                        mail.Subject = "Thank you for contacting us";
                        //sets the body
                        mail.Body = contact.Name + ", We'll contact you shortly <br /> <br /> We've been watching you.<br /> <br /> We know who you are. <br /><br /> Thanks, <br /> <br /> BYU Information Systems <br /> <br /> Reply with UNSUBSCRIBE to be removed from these emails";
                        //says that the body is html
                        mail.IsBodyHtml = true;

                        //sets up the smtp connection
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;

                        //the credentials are sent via smtp.
                        NetworkCredential networkCredential = new NetworkCredential(from, "jOoeH2gj");
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = networkCredential;
                        smtp.Port = 587;

                        //email is sent via smtp.
                        smtp.Send(mail);
                        ViewBag.Message = "Sent";
                        //creates the alert to be sent to the main page
                        TempData["msg"] = "<script>alert('Thank you. You will be contacted shortly.');</script>";
                        //returns you to the main page
                        return Redirect("/");
                    }
                
               
            }
            //if the model state was bad, you stay on the contact page.
            return View(contact);
        }

       
    }
}