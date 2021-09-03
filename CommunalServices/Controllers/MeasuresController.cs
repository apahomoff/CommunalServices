using CommunalServices.Model.EF;
using CommunalServices.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunalServices.Controllers
{
    public class MeasuresController : Controller
    {
        private AppDbContext db;

        public MeasuresController(AppDbContext db) => this.db = db;

        public IActionResult Index()
        {
            return View(db.Measures.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Measure measure)
        {
            if (TryValidateModel(measure))
            {
                db.Measures.Add(measure);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(measure);
            }
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Measure measure = db.Measures.Find(id);

            if (measure == null)
            {
                return NotFound();
            }

            return View(measure);
        }

        [HttpPost]
        public IActionResult Edit(Measure measure)
        {
            if (TryValidateModel(measure))
            {
                db.Entry(measure).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(measure);
            }
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Measure measure = db.Measures.Find(id);

            if (measure == null)
            {
                return NotFound();
            }

            return View(measure);
        }

        [HttpPost]
        public IActionResult Delete(Measure measure)
        {
            if (measure == null)
            {
                return BadRequest();
            }

            db.Measures.Remove(measure);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
