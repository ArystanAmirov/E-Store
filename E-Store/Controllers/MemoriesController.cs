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
    public class MemoriesController : Controller
    {
        private readonly IMemoriesService _service;

        public MemoriesController(IMemoriesService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allMemories = await _service.GetAllAsync();
            return View(allMemories);
        }

        //GET: memories/details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var memoryDetails = await _service.GetByIdAsync(id);
            if (memoryDetails == null) return View("NotFound");
            return View(memoryDetails);
        }

        //GET: memories/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,Name,Description")]Memory memory)
        {
            if (!ModelState.IsValid) return View(memory);

            await _service.AddAsync(memory);
            return RedirectToAction(nameof(Index));
        }

        //GET: memories/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var memoryDetails = await _service.GetByIdAsync(id);
            if (memoryDetails == null) return View("NotFound");
            return View(memoryDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,Name,Description")] Memory memory)
        {
            if (!ModelState.IsValid) return View(memory);

            if(id == memory.Id)
            {
                await _service.UpdateAsync(id, memory);
                return RedirectToAction(nameof(Index));
            }
            return View(memory);
        }

        //GET: memories/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var memoryDetails = await _service.GetByIdAsync(id);
            if (memoryDetails == null) return View("NotFound");
            return View(memoryDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var memoryDetails = await _service.GetByIdAsync(id);
            if (memoryDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
