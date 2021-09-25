using CommunalServices.Model;
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
        private IRepository repository;

        public NormGigacaloriesController(IRepository repository) => this.repository = repository;

        public async Task<IActionResult> Index()
        {
            return View(await repository.GetAllAsync<NormGigacalorie>());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NormGigacalorie normGigacalorie)
        {
            // TODO Разобраться с валидацией float
            if (ModelState.IsValid)
            {
                await repository.CreateAsync(normGigacalorie);
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

            var normGigacalorie = await repository.GetAsync<NormGigacalorie>(id.Value);

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
            if (ModelState.IsValid)
            {
                await repository.EditAsync(normGigacalorie);
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

            var normGigacalorie = await repository.GetAsync<NormGigacalorie>(id.Value);

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

            await repository.RemoveAsync(normGigacalorie);

            return RedirectToAction("Index");
        }
    }
}
