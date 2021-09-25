using CommunalServices.Model.EF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunalServices.Model.Entities;
using Microsoft.EntityFrameworkCore;
using CommunalServices.Model;

namespace CommunalServices.Controllers
{
    public class TariffsController : Controller
    {
        private IRepository repository;

        public TariffsController(IRepository repository) => this.repository = repository;

        public IActionResult Create(int? serviceTypeId)
        {
            if (serviceTypeId == null)
            {
                return BadRequest();
            }

            ViewBag.ServiceTypeId = serviceTypeId.Value;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Tariff tariff)
        {
            // TODO Разобраться с валидацией float
            if (ModelState.IsValid)
            {
                await repository.CreateAsync(tariff);
                return RedirectToAction("Details", "ServiceTypes", new { id = tariff.ServiceTypeId });
            }
            else
            {
                ViewBag.ServiceTypeId = tariff.ServiceTypeId;
                return View(tariff);
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var tariff = await repository.GetAsync<Tariff>(id.Value);

            if (tariff == null)
            {
                return NotFound();
            }

            return View(tariff);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Tariff tariff)
        {
            // TODO Разобраться с валидацией float
            if (ModelState.IsValid)
            {
                await repository.EditAsync(tariff);
                return RedirectToAction("Details", "ServiceTypes", new {id = tariff.ServiceTypeId});
            }
            else
            {
                ViewBag.serviceTypeId = tariff.ServiceTypeId;
                return View(tariff);
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var tariff = await repository.GetAsync<Tariff>(id.Value);

            if (tariff == null)
            {
                return NotFound();
            }

            return View(tariff);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Tariff tariff)
        {
            if (tariff == null)
            {
                return BadRequest();
            }

            await repository.RemoveAsync(tariff);

            return RedirectToAction("Details", "ServiceTypes", new {id = tariff.ServiceTypeId});
        }
    }
}
