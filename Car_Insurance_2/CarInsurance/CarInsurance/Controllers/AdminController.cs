using CarInsurance.Models;
using CarInsurance.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsurance.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (Insurance_5Entities db = new Insurance_5Entities())
            {
                //var signups = db.SignUps.Where(x => x.Removed == null).ToList();
                // var signups = (from c in db.SignUps where c.Removed == null select c).ToList();
                var insures = db.Insurees;

                var InsureVms = new List<InsureeVm>();
                foreach (var insur in insures)
                {
                    var insureVm = new InsureeVm();
                    insureVm.Id = insur.Id;
                    insureVm.FirstName = insur.FirstName;
                    insureVm.LastName = insur.LastName;
                    insureVm.EmailAddress = insur.EmailAddress;
                    insureVm.Quote = insur.Quote;
                    InsureVms.Add(insureVm);


                }
                return View(InsureVms);
            }
            
        }
    }
}