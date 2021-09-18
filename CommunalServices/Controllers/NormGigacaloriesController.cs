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

        public async Task<IActionResult> Index()
        {
            return View(await db.NormGigacalories.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NormGigacalorie normGigacalorie)
        {
            // TODO Разобраться с валидацией float
            if (TryValidateModel(normGigacalorie))
            {
                await db.NormGigacalories.AddAsync(normGigacalorie);
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                return View(normGigacalorie);
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            NormGigacalorie normGigacalorie = await db.NormGigacalories.FindAsync(id);

            if (normGigacalorie == null)
            {
                return NotFound();
            }

            return View(normGigacalorie);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(NormGigacalorie normGigacalorie)
        {
            // TODO Разобраться с валидацией float
            if (TryValidateModel(normGigacalorie))
            {
                db.Entry(normGigacalorie).State = EntityState.Modified;
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                return View(normGigacalorie);
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            NormGigacalorie normGigacalorie = await db.NormGigacalories.FindAsync(id);

            if (normGigacalorie == null)
            {
                return NotFound();
            }

            return View(normGigacalorie);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(NormGigacalorie normGigacalorie)
        {
            if (normGigacalorie == null)
            {
                return BadRequest();
            }

            db.NormGigacalories.Remove(normGigacalorie);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
