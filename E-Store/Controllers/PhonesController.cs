using E_Store.Data;
using E_Store.Data.Services;
using E_Store.Data.Static;
using E_Store.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Store.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class PhonesController : Controller
    {
        private readonly IPhonesService _service;

        public PhonesController(IPhonesService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allPhones = await _service.GetAllAsync(n => n.CPU);
            return View(allPhones);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allPhones = await _service.GetAllAsync(n => n.CPU);

            if (!string.IsNullOrEmpty(searchString))
            {
               var filteredResultNew = allPhones.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allPhones);
        }

        //GET: Phones/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var phoneDetail = await _service.GetPhoneByIdAsync(id);
            return View(phoneDetail);
        }

        //GET: Phones/Create
        public async Task<IActionResult> Create()
        {
            var phoneDropdownsData = await _service.GetNewPhoneDropdownsValues();

            ViewBag.CPUs = new SelectList(phoneDropdownsData.CPUs, "Id", "Name");
            ViewBag.Memories = new SelectList(phoneDropdownsData.Memories, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewPhoneVM phone)
        {
            if (!ModelState.IsValid)
            {
                var phoneDropdownsData = await _service.GetNewPhoneDropdownsValues();

                ViewBag.CPUs = new SelectList(phoneDropdownsData.CPUs, "Id", "Name");
                ViewBag.Memories = new SelectList(phoneDropdownsData.Memories, "Id", "Name");

                return View(phone);
            }

            await _service.AddNewPhoneAsync(phone);
            return RedirectToAction(nameof(Index));
        }


        //GET: Phones/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var phoneDetails = await _service.GetPhoneByIdAsync(id);
            if (phoneDetails == null) return View("NotFound");

            var response = new NewPhoneVM()
            {
                Id = phoneDetails.Id,
                Name = phoneDetails.Name,
                Description = phoneDetails.Description,
                Price = phoneDetails.Price,
                ImageURL = phoneDetails.ImageURL,
                PhoneColour = phoneDetails.PhoneColour,
                CPUId = phoneDetails.CPUId,
                MemoryId = phoneDetails.MemoryId,
            };

            var phoneDropdownsData = await _service.GetNewPhoneDropdownsValues();
            ViewBag.CPUs = new SelectList(phoneDropdownsData.CPUs, "Id", "Name");
            ViewBag.Memories = new SelectList(phoneDropdownsData.Memories, "Id", "Name");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewPhoneVM phone)
        {
            if (id != phone.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var phoneDropdownsData = await _service.GetNewPhoneDropdownsValues();

                ViewBag.CPUs = new SelectList(phoneDropdownsData.CPUs, "Id", "Name");
                ViewBag.Memories = new SelectList(phoneDropdownsData.Memories, "Id", "Name");

                return View(phone);
            }

            await _service.UpdatePhoneAsync(phone);
            return RedirectToAction(nameof(Index));
        }

        //GET: Phones/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var phoneDetails = await _service.GetByIdAsync(id);
            if (phoneDetails == null) return View("NotFound");
            return View(phoneDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phoneDetails = await _service.GetByIdAsync(id);
            if (phoneDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}