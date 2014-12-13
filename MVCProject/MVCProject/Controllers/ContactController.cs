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
                        mail.Subject = "This email is just for you";
                        mail.Body = contact.Name + ", We've been watching you.";

                        mail.IsBodyHtml = false;
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