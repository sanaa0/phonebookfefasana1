using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using phoneBook.Models;

namespace phoneBook.Controllers
{
    public class phoneBookController : Controller
    {
        // GET: phoneBook
        public ActionResult Index()
        {
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            var dblist = db.People;
            List<Person> listing = new List<Person>();
            foreach (var member in dblist )
            {
                if(member.AddedBy == User.Identity.GetUserId())
                {
                    Person p1 = new Person();
                    p1.AddedBy = User.Identity.GetUserId();
                    p1.AddedOn = Convert.ToDateTime  (member.AddedOn);
                    p1.DateOfBirth = Convert.ToDateTime(member.DateOfBirth);
                    p1.EmailId = member.EmailId;
                    p1.FaceBookAccountId = member.FaceBookAccountId;
                    p1.FirstName = member.FirstName;
                    p1.HomeAddress = member.HomeAddress;
                    p1.HomeCity = member.HomeCity;
                    p1.ImagePath = member.ImagePath;
                    p1.LastName = member.LastName;
                    p1.LinkedInId = member.LinkedInId;
                    p1.MiddleName = member.MiddleName;
                    p1.PersonId = member.PersonId;
                    p1.TwitterId = member.TwitterId;
                    p1.UpdateOn = Convert.ToDateTime(member.UpdateOn); 
                    listing.Add(p1);
                }
            }
            return View(listing);
        }

        // GET: phoneBook/Details/5
        public ActionResult Details(int id)
        {
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            var dblist = db.People;
           Person p1= new Person();
            foreach (var member in dblist)
            {
                if (member.PersonId == id)
                {
                   // Person p1 = new Person();
                    p1.AddedBy = User.Identity.GetUserId();
                    p1.AddedOn = Convert.ToDateTime(member.AddedOn);
                    p1.DateOfBirth = Convert.ToDateTime(member.DateOfBirth);
                    p1.EmailId = member.EmailId;
                    p1.FaceBookAccountId = member.FaceBookAccountId;
                    p1.FirstName = member.FirstName;
                    p1.HomeAddress = member.HomeAddress;
                    p1.HomeCity = member.HomeCity;
                    p1.ImagePath = member.ImagePath;
                    p1.LastName = member.LastName;
                    p1.LinkedInId = member.LinkedInId;
                    p1.MiddleName = member.MiddleName;
                    p1.PersonId = member.PersonId;
                    p1.TwitterId = member.TwitterId;
                    p1.UpdateOn = Convert.ToDateTime(member.UpdateOn);
                    
                }
            }
            return View(p1);
        }

        // GET: phoneBook/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: phoneBook/Create
        [HttpPost]
        public ActionResult Create(personviewmodel collection)
        {
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            try
            {
                // TODO: Add insert logic here
                Person p1 = new Person();
                p1.AddedBy = User.Identity.GetUserId();
                p1.AddedOn = DateTime.Now.Date;
                p1.DateOfBirth = collection.DateOfBirth;
                p1.EmailId = collection.EmailId;
                p1.FaceBookAccountId = collection.FaceBookAccountId;
                p1.FirstName = collection.FirstName;
                p1.HomeAddress = collection.HomeAddress;
                p1.HomeCity = collection.HomeCity;
                p1.ImagePath = collection.ImagePath;
                p1.LastName = collection.LastName;
                p1.LinkedInId = collection.LinkedInId;
                p1.MiddleName = collection.MiddleName;
                p1.PersonId = collection.PersonId;
                p1.TwitterId = collection.TwitterId;
                p1.UpdateOn = DateTime.Now.Date;
                db.People.Add(p1);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: phoneBook/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: phoneBook/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, personviewmodel collection)
        {
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            var p1 = db.People.Where(x => x.PersonId == id).First();
            try
            {
                // TODO: Add update logic here
                
                
                p1.AddedBy = Convert.ToString(  User.Identity.GetUserId());
                p1.AddedOn = DateTime.Now.Date;
                p1.DateOfBirth = collection.DateOfBirth;
                p1.EmailId = collection.EmailId;
                p1.FaceBookAccountId = collection.FaceBookAccountId;
                p1.FirstName = collection.FirstName;
                p1.HomeAddress = collection.HomeAddress;
                p1.HomeCity = collection.HomeCity;
                p1.ImagePath = collection.ImagePath;
                p1.LastName = collection.LastName;
                p1.LinkedInId = collection.LinkedInId;
                p1.MiddleName = collection.MiddleName;
                p1.PersonId = collection.PersonId;
                p1.TwitterId = collection.TwitterId;
                p1.UpdateOn = DateTime.Now.Date;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(p1);
            }
        }

        // GET: phoneBook/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: phoneBook/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, personviewmodel collection)
        {
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            Person delable = new Person();
            var converter  = db.People;
     
            try
            {
                foreach (var member in converter)
                {
                    if (member.PersonId == id)
                    {
                        delable = member;
                    }
                }
                db.People.Remove(delable);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(delable);
            }
        }
    }
}
