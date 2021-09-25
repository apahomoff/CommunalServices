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
    public class ProvidersController : Controller
    {
        private IRepository repository;

        public ProvidersController(IRepository repository) => this.repository = repository;

        public async Task<IActionResult> Index()
        {
            return View(await repository.GetAllAsync<Provider>());
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Provider provider)
        {
            if (ModelState.IsValid)
            {
                await repository.CreateAsync(provider);
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

            var provider = await repository.GetAsync<Provider>(id.Value);

            if (provider == null)
            {
                return NotFound();
            }

            return View(provider);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Provider provider)
        {
            if (ModelState.IsValid)
            {
                await repository.EditAsync(provider);
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

            var provider = await repository.GetAsync<Provider>(id.Value);

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

            await repository.RemoveAsync(provider);

            return RedirectToAction("Index");
        }
    }
}
