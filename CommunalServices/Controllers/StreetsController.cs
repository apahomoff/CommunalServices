using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunalServices.Model.EF;
using CommunalServices.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CommunalServices.Controllers
{
    public class StreetsController : Controller
    {
        private AppDbContext db;

        public StreetsController(AppDbContext db) => this.db = db;

        public IActionResult Index()
        {
            return View(db.Streets.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Street street)
        {
            if (TryValidateModel(street))
            {
                db.Streets.Add(street);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(street);
            }
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Street street = db.Streets.Find(id);

            if (street == null)
            {
                return NotFound();
            }

            return View(street);
        }

        [HttpPost]
        public IActionResult Edit(Street street)
        {
            if (TryValidateModel(street))
            {
                db.Entry(street).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(street);
            }
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Street street = db.Streets.Find(id);

            if (street == null)
            {
                return NotFound();
            }

            return View(street);

        }

        [HttpPost]
        public IActionResult Delete(Street street)
        {
            if (street == null)
            {
                return BadRequest();
            }

            db.Streets.Remove(street);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
