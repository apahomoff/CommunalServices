using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunalServices.Model.EF;
using CommunalServices.Model.Entities;
using Microsoft.EntityFrameworkCore;
using CommunalServices.Model;

namespace CommunalServices.Controllers
{
    public class StreetsController : Controller
    {
        private IRepository repository;

        public StreetsController(IRepository repository) => this.repository = repository;

        public async Task<IActionResult> Index()
        {
            return View(await repository.GetAllAsync<Street>());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Street street)
        {
            if (ModelState.IsValid)
            {
                await repository.CreateAsync(street);
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

            var street = await repository.GetAsync<Street>(id.Value);

            if (street == null)
            {
                return NotFound();
            }

            return View(street);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Street street)
        {
            if (ModelState.IsValid)
            {
                await repository.EditAsync(street);
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

            var street = await repository.GetAsync<Street>(id.Value);

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

            await repository.RemoveAsync(street);

            return RedirectToAction("Index");
        }
    }
}
