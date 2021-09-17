using CommunalServices.Model.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunalServices.Model.Entities;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace CommunalServices.Controllers
{
    public class ServiceTypesController : Controller
    {
        private AppDbContext db;

        public ServiceTypesController(AppDbContext db) => this.db = db;

        public async Task<IActionResult> Index()
        {
            return View(await db.ServiceTypes.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewBag.MeasureId = new SelectList(db.Measures, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ServiceType serviceType)
        {
            if (TryValidateModel(serviceType))
            {
                await db.ServiceTypes.AddAsync(serviceType);
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                return View(serviceType);
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            ServiceType serviceType = await db.ServiceTypes
                .Include(s => s.Measure)
                .Include(s => s.Tariffs)
                .Include(s => s.ServiceProviders)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (serviceType == null)
            {
                return NotFound();
            }

            foreach (var serviceProvider in serviceType.ServiceProviders)
            {
                serviceProvider.Provider = await db.Providers.FindAsync(serviceProvider.ProviderId);
            }

            return View(serviceType);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            ServiceType serviceType = await db.ServiceTypes.FindAsync(id);

            if (serviceType == null)
            {
                return NotFound();
            }

            ViewBag.MeasureId = new SelectList(db.Measures, "Id", "Name");

            return View(serviceType);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ServiceType serviceType)
        {
            if (TryValidateModel(serviceType))
            {
                db.Entry(serviceType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                //ViewBag.id = serviceType.Id;

                return View("Details", serviceType);
            }
            else
            {
                return View(serviceType);
            }
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            ServiceType serviceType = db.ServiceTypes.Find(id);

            if (serviceType == null)
            {
                return NotFound();
            }

            return View(serviceType);
        }

        [HttpPost]
        public IActionResult Delete(ServiceType serviceType)
        {
            if (serviceType == null)
            {
                return BadRequest();
            }

            db.ServiceTypes.Remove(serviceType);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
