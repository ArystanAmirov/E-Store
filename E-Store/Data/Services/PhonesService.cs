using E_Store.Data.Base;
using E_Store.Data.ViewModels;
using E_Store.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Store.Data.Services
{
    public class PhonesService : EntityBaseRepository<Phone>, IPhonesService
    {
        private readonly AppDbContext _context;
        public PhonesService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewPhoneAsync(NewPhoneVM data)
        {
            var newPhone = new Phone()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                CPUId = data.CPUId,
                PhoneColour = data.PhoneColour,
                MemoryId = data.MemoryId
            };
            await _context.Phones.AddAsync(newPhone);
            await _context.SaveChangesAsync();

            await _context.SaveChangesAsync();
        }

        public async Task<Phone> GetPhoneByIdAsync(int id)
        {
            var phoneDetails = await _context.Phones
                .Include(c => c.CPU)
                .Include(p => p.Memory)
                .FirstOrDefaultAsync(n => n.Id == id);

            return phoneDetails;
        }

        public async Task<NewPhoneDropdownsVM> GetNewPhoneDropdownsValues()
        {
            var response = new NewPhoneDropdownsVM()
            {
                CPUs = await _context.CPUs.OrderBy(n => n.Name).ToListAsync(),
                Memories = await _context.Memories.OrderBy(n => n.Name).ToListAsync()
            };

            return response;
        }

        public async Task UpdatePhoneAsync(NewPhoneVM data)
        {
            var dbPhone = await _context.Phones.FirstOrDefaultAsync(n => n.Id == data.Id);

            if(dbPhone != null)
            {
                dbPhone.Name = data.Name;
                dbPhone.Description = data.Description;
                dbPhone.Price = data.Price;
                dbPhone.ImageURL = data.ImageURL;
                dbPhone.CPUId = data.CPUId;
                dbPhone.PhoneColour = data.PhoneColour;
                dbPhone.MemoryId = data.MemoryId;
                await _context.SaveChangesAsync();
            }

            await _context.SaveChangesAsync();
        }
    }
}
