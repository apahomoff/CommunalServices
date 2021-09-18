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

        public async Task<IActionResult> Index()
        {
            return View(await db.Providers.ToListAsync());
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Provider provider)
        {
            if (TryValidateModel(provider))
            {
                await db.Providers.AddAsync(provider);
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                return View(provider);
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Provider provider = await db.Providers.FindAsync(id);

            if (provider == null)
            {
                return NotFound();
            }

            return View(provider);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Provider provider)
        {
            if (TryValidateModel(provider))
            {
                db.Entry(provider).State = EntityState.Modified;
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                return View(provider);
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Provider provider = await db.Providers.FindAsync(id);

            if (provider == null)
            {
                return NotFound();
            }

            return View(provider);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Provider provider)
        {
            if (provider == null)
            {
                return BadRequest();
            }

            db.Providers.Remove(provider);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
