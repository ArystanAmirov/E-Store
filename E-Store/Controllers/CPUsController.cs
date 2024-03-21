using E_Store.Data;
using E_Store.Data.Services;
using E_Store.Data.Static;
using E_Store.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Store.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class CPUsController : Controller
    {
        private readonly ICPUsService _service;

        public CPUsController(ICPUsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allCPUs = await _service.GetAllAsync();
            return View(allCPUs);
        }


        //Get: CPUs/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")]CPU cpu)
        {
            if (!ModelState.IsValid) return View(cpu);
            await _service.AddAsync(cpu);
            return RedirectToAction(nameof(Index));
        }

        //Get: CPUs/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var cpuDetails = await _service.GetByIdAsync(id);
            if (cpuDetails == null) return View("NotFound");
            return View(cpuDetails);
        }

        //Get: CPUs/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var cpuDetails = await _service.GetByIdAsync(id);
            if (cpuDetails == null) return View("NotFound");
            return View(cpuDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] CPU cpu)
        {
            if (!ModelState.IsValid) return View(cpu);
            await _service.UpdateAsync(id, cpu);
            return RedirectToAction(nameof(Index));
        }

        //Get: CPUs/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var cpuDetails = await _service.GetByIdAsync(id);
            if (cpuDetails == null) return View("NotFound");
            return View(cpuDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var cpuDetails = await _service.GetByIdAsync(id);
            if (cpuDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
