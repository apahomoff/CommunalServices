using CommunalServices.Model.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CommunalServices.Model.Entities;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using CommunalServices.Model;

namespace CommunalServices.Controllers
{
    public class ServiceTypesController : Controller
    {
        private IRepository repository;
        private AppDbContext db;

        public ServiceTypesController(IRepository repository, AppDbContext db)
        {
            this.repository = repository;
            this.db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await repository.GetAllAsync<ServiceType>());
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.MeasureId = new SelectList(await repository.GetAllAsync<Measure>(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ServiceType serviceType)
        {
            if (TryValidateModel(serviceType))
            {
                await repository.CreateAsync(serviceType);
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

            ServiceType serviceType = await repository.FirstOrDefaultAsync(
                s => s.Id == id, 
                new List<Expression<Func<ServiceType, object>>>
                {
                    {s => s.Measure},
                    {s => s.Tariffs},
                    {s => s.ServiceProviders}
                });

            if (serviceType == null)
            {
                return NotFound();
            }

            foreach (var serviceProvider in serviceType.ServiceProviders)
            {
                serviceProvider.Provider = await repository.GetAsync<Provider>(serviceProvider.ProviderId);
            }

            return View(serviceType);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var serviceType = await repository.GetAsync<ServiceType>(id.Value);

            if (serviceType == null)
            {
                return NotFound();
            }

            ViewBag.MeasureId = new SelectList(await repository.GetAllAsync<Measure>(), "Id", "Name");

            return View(serviceType);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ServiceType serviceType)
        {
            if (TryValidateModel(serviceType))
            {
                await repository.EditAsync(serviceType);
                return RedirectToAction("Details", serviceType);
            }
            else
            {
                return View(serviceType);
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var serviceType = await repository.GetAsync<ServiceType>(id.Value);

            if (serviceType == null)
            {
                return NotFound();
            }

            return View(serviceType);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ServiceType serviceType)
        {
            if (serviceType == null)
            {
                return BadRequest();
            }

            await repository.RemoveAsync(serviceType);

            return RedirectToAction("Index");
        }

    }
}
