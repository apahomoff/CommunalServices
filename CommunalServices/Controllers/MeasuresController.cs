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

        public async Task<IActionResult> Index()
        {
            return View(await db.Measures.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Measure measure)
        {
            if (TryValidateModel(measure))
            {
                await db.Measures.AddAsync(measure);
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                return View(measure);
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Measure measure = await db.Measures.FindAsync(id);

            if (measure == null)
            {
                return NotFound();
            }

            return View(measure);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Measure measure)
        {
            if (TryValidateModel(measure))
            {
                db.Entry(measure).State = EntityState.Modified;
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                return View(measure);
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Measure measure = await db.Measures.FindAsync(id);

            if (measure == null)
            {
                return NotFound();
            }

            return View(measure);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Measure measure)
        {
            if (measure == null)
            {
                return BadRequest();
            }

            db.Measures.Remove(measure);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
