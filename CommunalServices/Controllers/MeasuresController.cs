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
    public class MeasuresController : Controller
    {
        private IRepository repository;

        public MeasuresController(IRepository repository) => this.repository = repository;

        public async Task<IActionResult> Index()
        {
            return View(await repository.GetAllAsync<Measure>());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Measure measure)
        {
            if(ModelState.IsValid)
            {
                await repository.CreateAsync(measure);
                return RedirectToAction("Index");
            }
            else
            {
                return View(measure);
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var measure = await repository.GetAsync<Measure>(id.Value);

            if (measure == null)
            {
                return NotFound();
            }

            return View(measure);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Measure measure)
        {
            if (ModelState.IsValid)
            {
                await repository.EditAsync(measure);
                return RedirectToAction("Index");
            }
            else
            {
                return View(measure);
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var measure = await repository.GetAsync<Measure>(id.Value);

            if (measure == null)
            {
                return NotFound();
            }

            return View(measure);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Measure measure)
        {
            if (measure == null)
            {
                return BadRequest();
            }

            await repository.RemoveAsync(measure);

            return RedirectToAction("Index");
        }
    }
}
