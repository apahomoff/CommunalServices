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
    public class NormGigacaloriesController : Controller
    {
        private AppDbContext db;

        public NormGigacaloriesController(AppDbContext db) => this.db = db;

        public IActionResult Index()
        {
            return View(db.NormGigacalories.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(NormGigacalorie normGigacalorie)
        {
            // TODO Разобраться с валидацией float
            if (TryValidateModel(normGigacalorie))
            {
                db.NormGigacalories.Add(normGigacalorie);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(normGigacalorie);
            }
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            NormGigacalorie normGigacalorie = db.NormGigacalories.Find(id);

            if (normGigacalorie == null)
            {
                return NotFound();
            }

            return View(normGigacalorie);
        }

        [HttpPost]
        public IActionResult Edit(NormGigacalorie normGigacalorie)
        {
            // TODO Разобраться с валидацией float
            if (TryValidateModel(normGigacalorie))
            {
                db.Entry(normGigacalorie).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(normGigacalorie);
            }
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            NormGigacalorie normGigacalorie = db.NormGigacalories.Find(id);

            if (normGigacalorie == null)
            {
                return NotFound();
            }

            return View(normGigacalorie);
        }

        [HttpPost]
        public IActionResult Delete(NormGigacalorie normGigacalorie)
        {
            if (normGigacalorie == null)
            {
                return BadRequest();
            }

            db.NormGigacalories.Remove(normGigacalorie);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
