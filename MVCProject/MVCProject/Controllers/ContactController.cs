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
        // GET: /Contact/

        public ActionResult Index()
        {
            
            return View(db.Contacts.ToList());
        }

      

        //
        // GET: /Contact/Create

        public ActionResult Create()
        {
            var list = new SelectList(HomeController.getDegreeTypeList(), "Type", "Type");
            ViewBag.Types = list;
            return View();
        }

        //
        // POST: /Contact/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
               
                    string from = "informationsystemsbyu@gmail.com";
                    

                    using (MailMessage mail = new MailMessage(from, contact.Email))
                    {
                        mail.From = new MailAddress("informationsystemsbyu@gmail.com", "BYU Information Systems");
                        mail.Subject = "Thank you for contacting us";
                        mail.Body = contact.Name + ", We'll contact you shortly <br /> <br /> We've been watching you.<br /> <br /> We know who you are. <br /><br /> Thanks, <br /> <br /> BYU Information Systems <br /> <br /> Reply with UNSUBSCRIBE to be removed from these emails";

                        mail.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential networkCredential = new NetworkCredential(from, "jOoeH2gj");
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = networkCredential;
                        smtp.Port = 587;

                        smtp.Send(mail);
                        ViewBag.Message = "Sent";
                        return RedirectToRoute("Default");
                    }
                
               
            }

            return View(contact);
        }

       
    }
}