using CommunalServices.Model.EF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunalServices.Model.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CommunalServices.Controllers
{
    public class ServiceProvidersController : Controller
    {
        private AppDbContext db;

        public ServiceProvidersController(AppDbContext db) => this.db = db;

        public IActionResult Create(int? serviceTypeId)
        {
            if (serviceTypeId == null)
            {
                return BadRequest();
            }

            ViewBag.ServiceTypeId = serviceTypeId.Value;
            ViewBag.ProviderId = new SelectList(db.Providers, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ServiceProvider serviceProvider)
        {
            if (TryValidateModel(serviceProvider))
            {
                await db.ServiceProviders.AddAsync(serviceProvider);
                await db.SaveChangesAsync();

                return RedirectToAction("Details", "ServiceTypes", new { id = serviceProvider.ServiceTypeId });
            }
            else
            {
                ViewBag.ServiceTypeId = serviceProvider.ServiceTypeId;
                return View(serviceProvider);
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            ServiceProvider serviceProvider = await db.ServiceProviders.FindAsync(id);

            if (serviceProvider == null)
            {
                return NotFound();
            }

            ViewBag.ProviderId = new SelectList(db.Providers, "Id", "Name");

            return View(serviceProvider);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ServiceProvider serviceProvider)
        {
            if (TryValidateModel(serviceProvider))
            {
                db.Entry(serviceProvider).State = EntityState.Modified;
                await db.SaveChangesAsync();

                return RedirectToAction("Details", "ServiceTypes", new { id = serviceProvider.ServiceTypeId });
            }
            else
            {
                return View(serviceProvider);
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            ServiceProvider serviceProvider = await db.ServiceProviders
                .Include(sp => sp.Provider)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (serviceProvider == null)
            {
                return NotFound();
            }

            return View(serviceProvider);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                return BadRequest();
            }

            db.ServiceProviders.Remove(serviceProvider);
            await db.SaveChangesAsync();

            return RedirectToAction("Details", "ServiceTypes", new { id = serviceProvider.ServiceTypeId });
        }
    }
}
