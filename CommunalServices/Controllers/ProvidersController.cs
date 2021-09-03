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
    public class ProvidersController : Controller
    {
        private AppDbContext db;

        public ProvidersController(AppDbContext db) => this.db = db;

        public IActionResult Index()
        {
            return View(db.Providers.ToList());
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Provider provider)
        {
            if (TryValidateModel(provider))
            {
                db.Providers.Add(provider);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(provider);
            }
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Provider provider = db.Providers.Find(id);

            if (provider == null)
            {
                return NotFound();
            }

            return View(provider);
        }

        [HttpPost]
        public IActionResult Edit(Provider provider)
        {
            if (TryValidateModel(provider))
            {
                db.Entry(provider).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(provider);
            }
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Provider provider = db.Providers.Find(id);

            if (provider == null)
            {
                return NotFound();
            }

            return View(provider);
        }

        [HttpPost]
        public IActionResult Delete(Provider provider)
        {
            if (provider == null)
            {
                return BadRequest();
            }

            db.Providers.Remove(provider);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
