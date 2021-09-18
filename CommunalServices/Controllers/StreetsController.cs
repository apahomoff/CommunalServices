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

        public async Task<IActionResult> Index()
        {
            return View(await db.Streets.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Street street)
        {
            if (TryValidateModel(street))
            {
                await db.Streets.AddAsync(street);
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                return View(street);
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Street street = await db.Streets.FindAsync(id);

            if (street == null)
            {
                return NotFound();
            }

            return View(street);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Street street)
        {
            if (TryValidateModel(street))
            {
                db.Entry(street).State = EntityState.Modified;
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                return View(street);
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Street street = await db.Streets.FindAsync(id);

            if (street == null)
            {
                return NotFound();
            }

            return View(street);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Street street)
        {
            if (street == null)
            {
                return BadRequest();
            }

            db.Streets.Remove(street);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
