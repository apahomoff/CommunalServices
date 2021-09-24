using CommunalServices.Model.EF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CommunalServices.Model.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CommunalServices.Model;

namespace CommunalServices.Controllers
{
    public class ServiceProvidersController : Controller
    {
        private IRepository repository;

        public ServiceProvidersController(IRepository repository) => this.repository = repository;

        public async Task<IActionResult> Create(int? serviceTypeId)
        {
            if (serviceTypeId == null)
            {
                return BadRequest();
            }

            ViewBag.ServiceTypeId = serviceTypeId.Value;
            ViewBag.ProviderId = new SelectList(await repository.GetAllAsync<Provider>(), "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ServiceProvider serviceProvider)
        {
            if (TryValidateModel(serviceProvider))
            {
                await repository.CreateAsync(serviceProvider);
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

            var serviceProvider = await repository.GetAsync<ServiceProvider>(id.Value);

            if (serviceProvider == null)
            {
                return NotFound();
            }

            ViewBag.ProviderId = new SelectList(await repository.GetAllAsync<Provider>(), "Id", "Name");

            return View(serviceProvider);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ServiceProvider serviceProvider)
        {
            if (TryValidateModel(serviceProvider))
            {
                await repository.EditAsync(serviceProvider);
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

            ServiceProvider serviceProvider = await repository.FirstOrDefaultAsync(
                sp => sp.Id == id,
                new List<Expression<Func<ServiceProvider, object>>>
                {{sp => sp.Provider}});

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

            await repository.RemoveAsync(serviceProvider);

            return RedirectToAction("Details", "ServiceTypes", new { id = serviceProvider.ServiceTypeId });
        }
    }
}
