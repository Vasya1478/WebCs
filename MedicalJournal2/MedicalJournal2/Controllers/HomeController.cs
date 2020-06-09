using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MedicalJournal2.Models;

namespace MedicalJournal2.Controllers
{
    public class HomeController : Controller
    {
        stomatologyContext sc;
        public HomeController(stomatologyContext context)
        {
            sc = context;
        }
        stomatologyContext db = new stomatologyContext();


        public IActionResult Index()
        {
            //IEnumerable<Patients> patients = db.Patients;
            //ViewBag.Patients = patients;
            return View(db.Patients.ToList());
        }

        public IActionResult Detail(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

                Patients patient = db.Patients.Find(id);

            if (patient != null)
                return View(patient);

            return RedirectToAction("Index");

            
        }

        public IActionResult Search(string searchtext)
        {
            var patient = db.Patients.Where(p => p.Name.Contains(searchtext)).ToList();

            return View("Index", patient);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Journal()
        {
            return View(db.Journal.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
