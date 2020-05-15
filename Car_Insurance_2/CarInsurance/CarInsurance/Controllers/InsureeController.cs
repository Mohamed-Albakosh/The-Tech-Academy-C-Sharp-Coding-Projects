using CarInsurance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsurance.Controllers
{
    public class InsureeController : Controller
    {
        // GET: Insuree
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insuree(string firstName, string lastName, string emailAddress, DateTime dateOfBirth, int carYear, string carMake,
                                   string carModel, int speedingTickets, bool dUI, bool coverageType)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(emailAddress))
            {
                return View("~/Views/Shared/Error.cshtml");

            }
            using (Insurance_5Entities db = new Insurance_5Entities())
            {

                var insure = new Insuree();
                insure.FirstName = firstName;
                insure.LastName = lastName;
                insure.EmailAddress = emailAddress;
                insure.DateOfBirth = dateOfBirth;
                insure.CarYear = carYear;
                insure.CarMake = carMake;
                insure.CarModel = carModel;
                insure.DUI = dUI;
                insure.SpeedingTickets = speedingTickets;
                insure.CoverageType = coverageType;
                decimal quote = 50;
                var today = DateTime.Today;
                var age = today.Year - dateOfBirth.Year;
                if (age < 25)
                {
                    quote += 25;

                }
                else if (age < 18)
                {
                    quote += 100;
                }
                else if (age > 100)
                {
                    quote += 25;
                }
                if (carYear < 2000 || carYear > 2015)
                {
                    quote += 25;
                }
                if (carMake == "Porsche" || carMake == "Porsche" && carModel == "911 Carrera")
                {
                    quote += 25;
                }
                if (dUI == true)
                {
                    quote += 25;

                }
                if (coverageType == true)
                {
                    quote += 50;
                }

                insure.Quote = quote;

                db.Insurees.Add(insure);

                db.SaveChanges();
            }
            return View("Seccess");

        }
        public ActionResult Results()
        {
            using (Insurance_5Entities db = new Insurance_5Entities())
            {
                //var signups = db.SignUps.Where(x => x.Removed == null).ToList();

                var insures = db.Insurees;

                var Insures = new List<Insuree>();
                foreach (var insur in insures)
                {
                    var insure = new Insuree();
                    insure.Id = insur.Id;
                    insure.FirstName = insur.FirstName;
                    insure.LastName = insur.LastName;
                    insure.EmailAddress = insur.EmailAddress;
                    insure.DateOfBirth = insur.DateOfBirth;
                    insure.CarYear = insur.CarYear;
                    insure.CarMake = insur.CarMake;
                    insure.CarModel = insur.CarModel;
                    insure.DUI = insur.DUI;
                    insure.SpeedingTickets = insur.SpeedingTickets;
                    insure.CoverageType = insur.CoverageType;
                    insure.Quote = insur.Quote;
                    Insures.Add(insure);


                }
                return View(Insures);
            }
        }
    }
}