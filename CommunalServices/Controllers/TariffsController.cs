using CommunalServices.Model.EF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunalServices.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CommunalServices.Controllers
{
    public class TariffsController : Controller
    {
        private AppDbContext db;

        public TariffsController(AppDbContext db) => this.db = db;

        public IActionResult Create(int? serviceTypeId)
        {
            if (serviceTypeId == null)
            {
                return BadRequest();
            }

            ViewBag.serviceTypeId = serviceTypeId.Value;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Tariff tariff)
        {
            // TODO Разобраться с валидацией float
            if (TryValidateModel(tariff))
            {
                await db.Tariffs.AddAsync(tariff);
                await db.SaveChangesAsync();

                return RedirectToAction("Details", "ServiceTypes", new { id = tariff.ServiceTypeId });
            }
            else
            {
                ViewBag.serviceTypeId = tariff.ServiceTypeId;
                return View(tariff);
            }
        }

        public async Task<IActionResult> Edit(int? id, int? serviceTypeId)
        {
            if (id == null || serviceTypeId == null)
            {
                return BadRequest();
            }

            Tariff tariff = await db.Tariffs.FindAsync(id);

            if (tariff == null)
            {
                return NotFound();
            }

            ViewBag.serviceTypeId = serviceTypeId.Value;

            return View(tariff);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Tariff tariff)
        {
            // TODO Разобраться с валидацией float
            if (TryValidateModel(tariff))
            {
                if (tariff.ServiceTypeId == 0)
                {
                    return BadRequest();
                }

                db.Entry(tariff).State = EntityState.Modified;
                await db.SaveChangesAsync();

                return RedirectToAction("Details", "ServiceTypes", new {id = tariff.ServiceTypeId});
            }
            else
            {
                ViewBag.serviceTypeId = tariff.ServiceTypeId;
                return View(tariff);
            }
        }

        public async Task<IActionResult> Delete(int? id, int? serviceTypeId)
        {
            if (id == null || serviceTypeId == null)
            {
                return BadRequest();
            }

            Tariff tariff = await db.Tariffs
                .Include(t => t.ServiceType)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (tariff == null)
            {
                return NotFound();
            }

            return View(tariff);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Tariff tariff)
        {
            if (tariff == null || tariff.ServiceTypeId == 0)
            {
                return BadRequest();
            }

            db.Tariffs.Remove(tariff);
            await db.SaveChangesAsync();

            return RedirectToAction("Details", "ServiceTypes", new {id = tariff.ServiceTypeId});
        }
    }
}
